using System;
using System.Diagnostics;
using System.IO;
using USC.GISResearchLab.Common.Utils.Files;

namespace USC.GISResearchLab.Common.Diagnostics.TraceListeners
{
    public class LogFileTraceListener : TextWriterTraceListener
    {

        #region Properties
        //public static string baseNameSpace = "USC.GISResearchLab.Esri10x.Commands.Cartifactory.";
        private string _BaseNameSpace;

        public string BaseNameSpace
        {
            get { return _BaseNameSpace; }
            set { _BaseNameSpace = value; }
        }
        #endregion

        // for our constructors, explicitly call the base class constructor.
        public LogFileTraceListener(Stream stream, string name, string baseNameSpace) : base(stream, name) { BaseNameSpace = baseNameSpace; }
        public LogFileTraceListener(Stream stream, string baseNameSpace) : base(stream) { BaseNameSpace = baseNameSpace; }
        public LogFileTraceListener(TextWriter writer, string name, string baseNameSpace) : base(writer, name) { BaseNameSpace = baseNameSpace; }
        public LogFileTraceListener(TextWriter writer, string baseNameSpace) : base(writer) { BaseNameSpace = baseNameSpace; }

        public LogFileTraceListener(string fileName, string name, string baseNameSpace) : base(fileName, name)
        {
            if (!FileUtils.FileExists(fileName))
            {
                FileUtils.CreateTextFile(fileName);
            }
            BaseNameSpace = baseNameSpace;
        }

        public LogFileTraceListener(string fileName, string baseNameSpace) : base(fileName)
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                if (!FileUtils.FileExists(fileName))
                {
                    FileUtils.CreateTextFile(fileName);
                }
                BaseNameSpace = baseNameSpace;
            }
        }


        public override void Write(string message)
        {
            if (!String.IsNullOrEmpty(message))
            {
                base.Write(message);
            }
        }

        public override void WriteLine(string message)
        {
            if (!String.IsNullOrEmpty(message))
            {
                if (base.Writer != null)
                {
                    base.Writer.WriteLine(message);
                }
            }
        }
    }
}
