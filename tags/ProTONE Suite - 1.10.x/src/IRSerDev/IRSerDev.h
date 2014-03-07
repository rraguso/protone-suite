#include <windows.h>
#pragma once

#define WIN32_LEAN_AND_MEAN

typedef void (__stdcall *CallbackProc)(__int64);

// Initialize the serial port for the remote control serial device
int __stdcall PortInit(LPCTSTR lpszPortName, DCB initDcb);
// DLL Import for .NET C# apps:
// [DllImport("IRSerDev.dll", CallingConvention = CallingConvention.StdCall)]
// public static extern int PortInit(string lpszPortName, DCB initDcb);

// Close/cleanup the serial port for the remote control serial device
int __stdcall PortClose();
// DLL Import for .NET C# apps:
// [DllImport("IRSerDev.dll", CallingConvention = CallingConvention.StdCall)]
// public static extern int PortClose();

// Callback function for the remote control serial device driver.
void __stdcall RegisterCallback(CallbackProc callbackFunc);
// DLL Import for .NET C# apps:
// [DllImport("IRSerDev.dll", CallingConvention = CallingConvention.StdCall)]
// public static extern void RegisterCallback(IntPtr callbackFunc);

