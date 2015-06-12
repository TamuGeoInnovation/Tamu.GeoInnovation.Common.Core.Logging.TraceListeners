using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace USC.GISResearchLab.Common.Diagnostics.TraceListeners
{
    public class CustomTraceListener: TextWriterTraceListener { 
	
		// for our constructors, explicitly call the base class constructor.
        public CustomTraceListener(Stream stream, string name) : base(stream, name) { }
        public CustomTraceListener(Stream stream) : base(stream) { }
        public CustomTraceListener(string fileName, string name) : base(fileName, name) { }
        public CustomTraceListener(string fileName) : base(fileName) { }
		public CustomTraceListener( TextWriter writer, string name ) : base(writer, name) { }
        public CustomTraceListener(TextWriter writer) : base(writer) { }


        public override void Write(string message)
        {
            string msg = getPreambleMessage() + message;
            base.Write(msg);
            //this.Flush();
        }

        public override void WriteLine(string message)
        {
            //string msg = getPreambleMessage() + message;
            Writer.WriteLine(message);
            //this.Flush();
        }


        [MethodImpl(
             MethodImplOptions.NoInlining)]
        private string getPreambleMessage()
        {
            StringBuilder preamble = new StringBuilder();
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame;
            MethodBase stackFrameMethod;

            int frameCount = 0;
            string typeName;
            do
            {
                frameCount++;
                stackFrame = stackTrace.GetFrame(frameCount);
                stackFrameMethod = stackFrame.GetMethod();
                typeName = stackFrameMethod.ReflectedType.FullName;
            }
            while (typeName.StartsWith("System") || typeName.EndsWith("CustomTraceListener"));

            //log DateTime, Namespace, Class and Method Name
            preamble.Append(DateTime.Now.ToString());
            preamble.Append(": ");
            preamble.Append(typeName);
            preamble.Append(".");
            preamble.Append(stackFrameMethod.Name);
            preamble.Append("(");

            // log parameter types and names
            ParameterInfo[] parameters = stackFrameMethod.GetParameters();
            int parameterIndex = 0;
            while (parameterIndex < parameters.Length)
            {
                preamble.Append(parameters[parameterIndex].ParameterType.Name);
                preamble.Append(" ");
                preamble.Append(parameters[parameterIndex].Name);
                parameterIndex++;
                if (parameterIndex != parameters.Length) preamble.Append(", ");
            }

            preamble.Append("): ");

            return preamble.ToString();

        }
	}
}
