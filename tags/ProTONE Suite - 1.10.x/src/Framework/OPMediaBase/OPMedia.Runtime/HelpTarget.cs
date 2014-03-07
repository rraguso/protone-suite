using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPMedia.OSDependentLayer;
using System.Windows.Forms;
using OPMedia.Runtime.Logging;

namespace OPMedia.Runtime
{
    public class HelpTarget<T> : EventTarget
    {
        public const int DefaultHelpTopic = 5000;

        public HelpTarget() : base(EventNames.HelpRequest)
        {
        }

        public override void ProcessNotification(string eventName, object[] eventData)
        {
            Control ctl = null;
            string requestedTopic = string.Empty;
            string requestedHelpFile = string.Empty;

            int i = 0;
            if (eventData.Length > i)
            {
                ctl = eventData[i++] as Control;
            }
            if (eventData.Length > i)
            {
                requestedTopic = eventData[i++] as string;
            }
            if (eventData.Length > i)
            {
                requestedHelpFile = eventData[i++] as string;
            }

            int topic = DefaultHelpTopic;
            try
            {
                topic = (int)Enum.Parse(typeof(T), requestedTopic);
            }
            catch
            {
                topic = DefaultHelpTopic;
            }

            Logger.LogHelpTrace("helpTopic:{0} ... helpFile:{1}", requestedTopic, requestedHelpFile);

            Help.ShowHelp(ctl,
                string.IsNullOrEmpty(requestedHelpFile) ? SuiteConfiguration.HelpFilePath : requestedHelpFile,
                HelpNavigator.TopicId, topic.ToString());
        }
    }
}
