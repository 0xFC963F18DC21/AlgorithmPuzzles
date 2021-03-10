using System;
using System.Linq;
using NrgteUnit;

namespace AlgorithmPuzzles {
    internal static class EntryPoint {
        private static void Main() {
            var type = typeof(ISolution);
            var solutions = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p != type)
                .ToArray();

            var results = TestRunner.RunTestClasses(solutions);
            foreach (var failure in results) {
                Console.WriteLine(failure);
            }
        }
    }
}