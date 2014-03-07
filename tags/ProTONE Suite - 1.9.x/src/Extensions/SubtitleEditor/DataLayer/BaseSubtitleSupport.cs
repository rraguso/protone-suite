using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubtitleEditor.extension.DataLayer
{
    public abstract class BaseSubtitleSupport
    {
        protected string _file = string.Empty;
        protected Subtitle _sub = null;

        public BaseSubtitleSupport(Subtitle sub, string file)
        {
            _sub = sub;
            _file = file;
        }

        public void Load()
        {
            DoLoad(_file);
        }

        public void Save()
        {
            DoSave(_file);
        }

        protected abstract void DoLoad(string file);
        protected abstract void DoSave(string file);
    }
}
