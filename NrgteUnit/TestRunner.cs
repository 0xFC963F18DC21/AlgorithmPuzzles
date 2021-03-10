using System;
using System.Collections.Generic;
using System.Linq;

namespace NrgteUnit {
    /// <summary>
    /// Runs a set of test classes, returning any failures.
    /// </summary>
    public static class TestRunner {
        /// <summary>
        /// Runs classes with test methods, returning a list of failures if any happen.
        /// </summary>
        /// <param name="testClasses">Types of classes to test.</param>
        /// <returns></returns>
        public static List<Failure> RunTestClasses(params Type[] testClasses) {
            var failures = new List<Failure>();

            foreach (var testClass in testClasses) {
                var tests = from method in testClass.GetMethods()
                            where method.GetCustomAttributes(typeof(TestAttribute), true).Length > 0
                            select method;

                var activator = Activator.CreateInstance(testClass);
                if (activator == null) continue;

                foreach (var methodInfo in tests) {
                    try {
                        methodInfo.Invoke(activator, null);
                    } catch (Exception e) {
                        failures.Add(new Failure(e));
                    }
                }
            }

            return failures;
        }
    }
}