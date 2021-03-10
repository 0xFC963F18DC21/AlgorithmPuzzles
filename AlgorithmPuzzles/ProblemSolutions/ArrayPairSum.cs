using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NrgteUnit;
using NrgteUnit.Assert;

namespace AlgorithmPuzzles.ProblemSolutions {
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class ArrayPairSum : ISolution {
        private static bool NaivePairSum(int[] arr, int sum) {
            for (var i = 0; i < arr.Length - 1; ++i) {
                for (var j = i; j < arr.Length; ++j) {
                    if (arr[i] + arr[j] == sum) {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool OptimalPairSum(int[] arr, int sum) {
            var seen = new Dictionary<int, int>();
            foreach (var i in arr) {
                if (seen.ContainsKey(sum - i)) {
                    return true;
                }

                seen.Add(i, sum - i);
            }

            return false;
        }

        private int[] TestArr { get; } = { 8, 7, 2, 5, 3, 1 };
        private const int InThere = 10;
        private const int NotThere = 100;

        [Test]
        public void TestNaiveSolution() {
            Assertions.Assert(NaivePairSum(TestArr, InThere));
            Assertions.Assert(!NaivePairSum(TestArr, NotThere));
        }

        [Test]
        public void TestOptimalSolution() {
            Assertions.Assert(OptimalPairSum(TestArr, InThere));
            Assertions.Assert(!OptimalPairSum(TestArr, NotThere));
        }
    }
}