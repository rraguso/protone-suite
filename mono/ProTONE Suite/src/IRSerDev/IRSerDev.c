#include "IRSerDev.h"

HANDLE hThread    = NULL;
HANDLE hPort      = NULL;
HANDLE hStopEvent = NULL;
HANDLE hExitEvent = NULL;

OVERLAPPED ov;
DWORD dwThId = 0xffffffff;
CallbackProc callback = NULL;

enum DeviceErrorCodes
{
    ErrSuccess = 0,
    ErrPortOpen = -1,
    ErrSetGetCommState = -2,
    ErrCreateEvents = -3,
    ErrCreateRecvThread = -4,
    ErrSignalStop = -5,
    ErrStopThreadForced = -6,
};

DWORD WINAPI ReceiverThread( LPVOID lpParam );

int __stdcall PortInit(LPCTSTR lpszPortName)
{
	DCB initDcb;

	memset(&initDcb, 0, sizeof(DCB));
	initDcb.DCBlength = sizeof(DCB);
	initDcb.BaudRate = 9600;	// 9600 Bauds
	initDcb.ByteSize = 8;		// 8 Data Bits
	initDcb.Parity = 0;			// No parity
	initDcb.StopBits = 0;		// 1 Stop bit

	initDcb.fRtsControl = 1;	// Mandatory to set to 1 for the Serial Remote device
	initDcb.fDtrControl = 0;	// Mandatory to set to 0 for the Serial Remote device

    if(hPort != NULL)
    {
        SetCommMask(hPort,0);	// stop any waiting on the port
        Sleep(100);				// wait a tiny bit
        CloseHandle(hPort);		// and close it
        hPort=NULL;
    }
    
    hPort=CreateFile(lpszPortName,GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, 0);
        
    if (hPort == INVALID_HANDLE_VALUE)
    {
        hPort = NULL;
        return ErrPortOpen;
    }
    
    if(!SetCommState(hPort, &initDcb))
    {
        CloseHandle(hPort);
        hPort=NULL;
        return ErrSetGetCommState;
    }
    
    ov.hEvent = CreateEvent(NULL, TRUE, FALSE, NULL);
    if(ov.hEvent == NULL)
    {
        CloseHandle(hPort);
        hPort=NULL;
        return ErrCreateEvents;
    }
    
    hStopEvent = CreateEvent(NULL, TRUE, FALSE, NULL);
    if(hStopEvent == NULL)
    {
        CloseHandle(hPort);
        hPort=NULL;
        return ErrCreateEvents;
    }
    hExitEvent = CreateEvent(NULL, TRUE, FALSE, NULL);
    if(hExitEvent == NULL)
    {
        CloseHandle(hPort);
        hPort=NULL;
        return ErrCreateEvents;
    }
    
    hThread = CreateThread(NULL, 0, ReceiverThread, NULL, CREATE_SUSPENDED, &dwThId);
    if (hThread == NULL)
    {
        CloseHandle(hPort);
        CloseHandle(ov.hEvent);
        hPort = ov.hEvent = NULL;
        return ErrCreateRecvThread;
    }
    
    if (!SetThreadPriority(hThread, THREAD_PRIORITY_TIME_CRITICAL))
    {
        CloseHandle(hPort);
        CloseHandle(ov.hEvent);
        hPort = ov.hEvent = NULL;
        return ErrCreateRecvThread;
    }
    
    if (ResumeThread(hThread) < 0)
    {
        CloseHandle(hPort);
        CloseHandle(ov.hEvent);
        hPort = ov.hEvent = NULL;
        return ErrCreateRecvThread;
    }
    
	return ErrSuccess;
}

int __stdcall PortClose()
{
    int retVal = ErrSuccess;

	if (!SetEvent(hStopEvent))
    {
        return ErrSignalStop;
    }
    
    if (WaitForSingleObject(hExitEvent, 5000) != WAIT_OBJECT_0)
    {
        TerminateThread(hThread, 0);
        retVal = ErrStopThreadForced;
    }
    
    CloseHandle(hPort);
    CloseHandle(ov.hEvent);
    CloseHandle(hThread);
    CloseHandle(hStopEvent);
    CloseHandle(hExitEvent);
    
    return retVal;
}

void __stdcall RegisterCallback(CallbackProc callbackFunc)
{
    callback = callbackFunc;
}

DWORD WINAPI ReceiverThread(LPVOID lpParam ) 
{
    __int64 hr_time, hr_lasttime, hr_freq, diff;	// high-resolution
	int prev, dcd;
    HANDLE events[2] = { ov.hEvent, hStopEvent };
    DWORD evt, status, res;

    GetCommModemStatus(hPort, &status);
    prev = (status & MS_RLSD_ON) ? 1 : 0;
    
    /* Initialize timer stuff */
    QueryPerformanceFrequency((LARGE_INTEGER *)&hr_freq);
    
    /* Get time (both LR and HR) */
    QueryPerformanceCounter((LARGE_INTEGER *)&hr_lasttime);
    
    for(;;)
    {
        /* We want to be notified of DCD changes */
        if(SetCommMask(hPort, EV_RLSD) == 0)	
        {
            //DEBUG("SetCommMask returned zero, error=%d\n",GetLastError());
        }
        
        /* Reset the event */
        ResetEvent(ov.hEvent);

		/* Start waiting for the event */
        if(WaitCommEvent(hPort, &evt, &ov) == 0 && GetLastError() != 997 /* Overlapped I/O operation is in progress */)
        {
            //DEBUG("WaitCommEvent error: %d\n",GetLastError());
        }
        
        /* Wait for the event to get triggered */
        res = WaitForMultipleObjects(2, events, FALSE, INFINITE);
        
        /* Get time */
        QueryPerformanceCounter((LARGE_INTEGER *)&hr_time);
        
        if(res == WAIT_FAILED)
        {
            //DEBUG("Wait failed.\n");
            continue;
        }
        
        if(res == (WAIT_OBJECT_0+1))
        {
            //DEBUG("IRThread terminating\n");
            break;
        }
        
        if(res!=WAIT_OBJECT_0)
        {
            //DEBUG("Wrong object\n");
            continue;
        }
        
        if (!GetCommModemStatus(hPort, &status))
        {
            //DEBUG("Failed to get COM port status\n");
            continue;
        }
        
        dcd = (status & MS_RLSD_ON) ? 1 : 0;
        if(dcd == prev)
        {
            //DEBUG("COM port status did not change !\n");
            continue;
        }
        
        prev=dcd;
        
        diff = hr_time - hr_lasttime;
        hr_lasttime = hr_time;
        
        if (callback != NULL)
        {
           callback((diff * 1000000) / hr_freq);
        }
    }
    
    SetEvent(hExitEvent);
    return 0;
}
