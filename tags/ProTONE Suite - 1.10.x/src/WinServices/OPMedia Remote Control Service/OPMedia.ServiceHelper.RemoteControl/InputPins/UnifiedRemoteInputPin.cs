using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPMedia.ServiceHelper.RCCService.InputPins
{
    public class UnifiedRemoteInputPin : InputPin
    {
        public override bool IsConfigurable
        {
            get { return false; }
        }

        protected override string GetConfigDataInternal(string initialCfgData)
        {
            //LircCfgDlg dlg = new LircCfgDlg();

            //if (!string.IsNullOrEmpty(initialCfgData))
            //{
            //    dlg.Uri = initialCfgData;
            //}

            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    return dlg.Uri;
            //}

            return null;
        }

        protected override void StartInternal()
        {
        }

        protected override void StopInternal()
        {
        }

        protected override void ConfigureInternal()
        {
        }
    }
}
