using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

namespace APITesting.Helpers
{
    class ErrorExeptions : SpecFlowException
    {
        public ErrorExeptions()
        { }

        public ErrorExeptions(string message)
                : base(message) { }

        public ErrorExeptions(string format, params object[] args)
                : base(string.Format(format, args)) { }

        public ErrorExeptions(string message, Exception innerException)
                : base(message, innerException) { }

        public ErrorExeptions(string format, Exception innerException, params object[] args)
                : base(string.Format(format, args), innerException) { }
    }
}
