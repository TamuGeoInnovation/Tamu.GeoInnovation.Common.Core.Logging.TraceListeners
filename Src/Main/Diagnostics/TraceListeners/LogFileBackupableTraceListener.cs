using System.Diagnostics;
using System.IO;
using USC.GISResearchLab.Common.IOs.FileStreams;

namespace USC.GISResearchLab.Common.Diagnostics.TraceListeners
{
    public class LogFileBackupableTraceListener : TextWriterTraceListener
    {
        // for our constructors, explicitly call the base class constructor.
        public LogFileBackupableTraceListener(FileStreamWithBackup stream, string name) : base(stream, name) { }
        public LogFileBackupableTraceListener(FileStreamWithBackup stream) : base(stream) { }
        public LogFileBackupableTraceListener(TextWriter writer, string name) : base(writer, name) { }
        public LogFileBackupableTraceListener(TextWriter writer) : base(writer) { }

        public LogFileBackupableTraceListener(string fileName, string name, long maxFileLengthInBytes, int maxFileCount, FileMode mode)
            : base(new FileStreamWithBackup(fileName, maxFileLengthInBytes, maxFileCount, mode), name) { }

        public LogFileBackupableTraceListener(string fileName, long maxFileLengthInBytes, int maxFileCount, FileMode mode)
            : base(new FileStreamWithBackup(fileName, maxFileLengthInBytes, maxFileCount, mode)) { }


        //public override void Write(string message)
        //{
        //    base.Write(message);
        //}

        //public override void WriteLine(string message)
        //{
        //    base.Writer.WriteLine(message);
        //}
    }
}
