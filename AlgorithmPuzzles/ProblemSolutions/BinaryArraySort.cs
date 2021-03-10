using System.Diagnostics.CodeAnalysis;
using NrgteUnit;
using NrgteUnit.Assert;

namespace AlgorithmPuzzles.ProblemSolutions {
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class BinaryArraySort : ISolution {
        /// <summary>
        /// Sort a binary array which contains only 1s and 0s.
        /// Pre: Array must contain only 1s and 0s.
        /// </summary>
        /// <param name="binaryArray">Array to sort.</param>
        /// <returns>Sorted binary array.</returns>
        private static int[] CountSort(int[] binaryArray) {
            var result = new int[binaryArray.Length];
            var ptr = binaryArray.Length;

            foreach (var i in binaryArray) {
                if (i == 1) {
                    result[--ptr] = 1;
                }
            }

            return result;
        }

        [Test]
        public void TestBinaryArraySort() {
            int[] test1 = { 1, 0, 0, 1, 0, 1 };
            int[] test2 = { 1, 1, 0, 1, 0, 1, 0 };
            int[] test3 = { 0, 0, 0, 1, 0, 0, 1, 0 };

            int[] expected1 = { 0, 0, 0, 1, 1, 1 };
            int[] expected2 = { 0, 0, 0, 1, 1, 1, 1 };
            int[] expected3 = { 0, 0, 0, 0, 0, 0, 1, 1 };

            Assertions.AssertEnumerableEquals(expected1, CountSort(test1));
            Assertions.AssertEnumerableEquals(expected2, CountSort(test2));
            Assertions.AssertEnumerableEquals(expected3, CountSort(test3));
        }
    }
}