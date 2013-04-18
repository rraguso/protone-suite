using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using OPMedia.Core.GlobalEvents;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using OPMedia.Core.Logging;

namespace OPMedia.Core
{
    public static class EventDispatch
    {
        private static Dictionary<string, Dictionary<object, MethodInfo>> _invocationMap =
            new Dictionary<string, Dictionary<object, MethodInfo>>();

        public const string AllEvents = "*";

        static EventDispatch()
        {
            // Add the entry for "all" events
            _invocationMap.Add(AllEvents, new Dictionary<object, MethodInfo>());
        }

        public static void RegisterHandler(object handler)
        {
            if (handler != null)
            {
                BindingFlags bindingAttr = BindingFlags.NonPublic
                    | BindingFlags.Public
                    | BindingFlags.Instance
                    | BindingFlags.OptionalParamBinding
                    ;

                MethodInfo[] miArray = handler.GetType().GetMethods(bindingAttr);

                if (miArray != null)
                {
                    foreach (MethodInfo info in miArray)
                    {
                        object[] attrList = info.GetCustomAttributes(typeof(EventSinkAttribute), false);
                        if (attrList != null && attrList.Length > 0)
                        {
                            foreach (EventSinkAttribute attr in attrList)
                            {
                                List<string> eventNames = attr.EventNames;

                                if (eventNames == null || eventNames.Count < 1)
                                {
                                    SafeAddToInvocationMap(string.Empty, handler, info);
                                }
                                else foreach(string eventName in eventNames)
                                {
                                    SafeAddToInvocationMap(eventName, handler, info);
                                }
                            }
                        }
                    }
                }

                GC.Collect();
                DumpStatistics();
            }
        }

        private static void SafeAddToInvocationMap(string eventName, object handler, MethodInfo info)
        {
            lock (_invocationMap)
            {
                if (eventName == EventNames.PerformTranslation)
                {
                    //int x = 0;
                }
               

                if (!_invocationMap.ContainsKey(eventName))
                {
                    _invocationMap.Add(eventName, new Dictionary<object, MethodInfo>());
                }

                Dictionary<object, MethodInfo> table = _invocationMap[eventName];
                if (table != null)
                {
                    if (table.ContainsKey(handler))
                    {
                        table[handler] = info; // override existing information
                    }
                    else
                    {
                        table.Add(handler, info);
                    }
                }
            }
        }

        public static void UnregisterHandler(object handler)
        {
            if (handler != null)
            {
                lock (_invocationMap)
                {
                    foreach (Dictionary<object, MethodInfo> table in _invocationMap.Values)
                    {
                        if (table.ContainsKey(handler))
                        {
                            table.Remove(handler);
                        }
                    }
                }
            }

            GC.Collect();
            DumpStatistics();
        }

        private static Dictionary<object, MethodInfo> SafeCopy(Dictionary<object, MethodInfo> original)
        {
            Dictionary<object, MethodInfo> retVal = null;

            if (original != null)
            {
                retVal = new Dictionary<object, MethodInfo>();

                foreach (KeyValuePair<object, MethodInfo> kvp in original)
                {
                    if (retVal.ContainsKey(kvp.Key))
                    {
                        retVal[kvp.Key] = kvp.Value;
                    }
                    else
                    {
                        retVal.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            return retVal;
        }

        public static void DispatchEvent(string eventName, params object[] eventData)
        {
            Dictionary<object, MethodInfo> tableEvent = null;
            Dictionary<object, MethodInfo> tableAll = null;

            bool handlerNotFound = true; ;

            lock(_invocationMap)
            {
                if (_invocationMap.ContainsKey(eventName))
                {
                    //try
                    //{
                        tableEvent = SafeCopy(_invocationMap[eventName]);
                        tableAll = SafeCopy(_invocationMap[AllEvents]);
                    //}
                    //catch (Exception ex)
                    //{
                    //}

                    handlerNotFound = false;
                }
            }

            if (tableEvent != null)
            {
                foreach (KeyValuePair<object, MethodInfo> kvp in tableEvent)
                {
                    try
                    {
                        MainThread.Post(delegate(object x)
                        {
                            kvp.Value.Invoke(kvp.Key, eventData);

                        });
                    }
                    catch (TargetInvocationException ex)
                    {
                        ErrorDispatcher.DispatchError(ex.InnerException);
                    }
                    catch (Exception ex)
                    {
                        ErrorDispatcher.DispatchError(ex);
                    }
                }
            }

            if (tableAll != null)
            {
                foreach (KeyValuePair<object, MethodInfo> kvp in tableAll)
                {
                    try
                    {
                        kvp.Value.Invoke(kvp.Key, eventData);
                    }
                    catch (TargetInvocationException ex)
                    {
                        ErrorDispatcher.DispatchError(ex.InnerException);
                    }
                    catch (Exception ex)
                    {
                        ErrorDispatcher.DispatchError(ex);
                    }
                }
            }

            if (handlerNotFound)
            {
                if (eventName == EventNames.ShowMessageBox)
                {
                    ProcessMessageBoxEvent(eventData);
                }
            }
        }

        private static void ProcessMessageBoxEvent(params object[] eventData)
        {
            string message = string.Empty;
            string title = string.Empty;
            MessageBoxIcon icon = MessageBoxIcon.None;

            int i = 0;
            if (eventData.Length > i)
            {
                message = eventData[i++] as string;
            }
            if (eventData.Length > i)
            {
                title = eventData[i++] as string;
            }
            if (eventData.Length > i)
            {
                icon = (MessageBoxIcon)eventData[i++];
            }

            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        [Conditional("DUMP_EVENTDISPATCH_STATS")]
        private static void DumpStatistics()
        {
            StringBuilder sb = new StringBuilder();

            int objectCount = 0;
            foreach (KeyValuePair<string, Dictionary<object, MethodInfo>> kvp in _invocationMap)
            {
                Debug.WriteLine("EventDispatch: Event: {0} has {1} registered objects: ", 
                    kvp.Key, kvp.Value.Count);

                foreach (object obj in kvp.Value.Keys)
                {
                    Debug.WriteLine("EventDispatch:    Registered object:  {0}", obj);
                }

                objectCount += kvp.Value.Count;

            }

            //Debug.WriteLine("EventDispatch: # of registered events: {0}", _invocationMap.Count);
            Debug.WriteLine("EventDispatch: # of registered objects: {0}", objectCount);
        }

    }
}
