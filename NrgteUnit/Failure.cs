using System;
using System.Diagnostics;
using System.Reflection;

namespace NrgteUnit {
    /// <summary>
    /// Represents a test failure.
    /// </summary>
    public class Failure {
        private readonly string _test;
        private readonly int _whereLine;
        private readonly int _whereColumn;
        private readonly string _failureMessage;

        /// <summary>
        /// Make a new failure from a failed test's exception.
        /// </summary>
        /// <param name="e">Caught exception.</param>
        public Failure(Exception e) {
            var used = (e is TargetInvocationException ? e.InnerException : e) ?? e;

            var st = new StackTrace(used, true);
            var frame = st.GetFrame(1);

            _test = frame?.GetMethod()?.Name;
            _whereLine = frame?.GetFileLineNumber() ?? -1;
            _whereColumn = st.GetFrame(1)?.GetFileColumnNumber() ?? -1;
            _failureMessage = used.Message;
        }

        /// <summary>
        /// Converts this test failure to a string.
        /// </summary>
        /// <returns>String summarising the test failure.</returns>
        public override string ToString() {
            return $"{_test}({_whereLine}:{_whereColumn}): {_failureMessage}";
        }
    }
}