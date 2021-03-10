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

            foreach (var solutionType in solutions) {
                Console.WriteLine($"Testing class: {solutionType.Name}");

                var results = TestRunner.RunTestClasses(solutionType);
                foreach (var failure in results) {
                    Console.WriteLine(failure);
                }
            }
        }
    }
}