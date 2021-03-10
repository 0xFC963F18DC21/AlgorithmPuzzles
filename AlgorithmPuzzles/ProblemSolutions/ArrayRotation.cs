using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NrgteUnit;
using NrgteUnit.Assert;

namespace AlgorithmPuzzles.ProblemSolutions {
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class ArrayRotation : ISolution {
        private static void InPlaceRotate<T>(IList<T> iList, int amount) {
            while (true) {
                if (iList.Count <= 0) return;

                switch (amount) {
                    case > 0: {
                        var item = iList[0];

                        for (var i = 0; i < iList.Count - 1; ++i) {
                            iList[i] = iList[i + 1];
                        }

                        iList[^1] = item;

                        amount -= 1;
                        continue;
                    }
                    case < 0: {
                        var item = iList[^1];

                        for (var i = iList.Count - 1; i > 0; --i) {
                            iList[i] = iList[i - 1];
                        }

                        iList[0] = item;

                        amount += 1;
                        continue;
                    }
                    case 0:
                        return;
                }
            }
        }

        [Test]
        public void TestArrayRotations() {
            int[] a1 = { 1, 2, 3, 4, 5 };
            char[] a2 = { 'd', 'o', 'g' };
            float[] a3 = { 0.0f, 1.0f, 5.0f, 3.14f };

            int[] e1 = { 3, 4, 5, 1, 2 };
            char[] e2 = { 'g', 'd', 'o' };
            float[] e3 = { 0.0f, 1.0f, 5.0f, 3.14f };

            InPlaceRotate(a1, 2);
            InPlaceRotate(a2, -1);
            InPlaceRotate(a3, 0);

            Assertions.AssertEnumerableEquals(e1, a1);
            Assertions.AssertEnumerableEquals(e2, a2);
            Assertions.AssertEnumerableEquals(e3, a3);
        }
    }
}