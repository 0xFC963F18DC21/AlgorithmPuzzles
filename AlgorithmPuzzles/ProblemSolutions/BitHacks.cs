using System.Diagnostics.CodeAnalysis;
using NrgteUnit;
using NrgteUnit.Assert;

namespace AlgorithmPuzzles.ProblemSolutions {
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public class BitHacks : ISolution {
        /// <summary>
        /// Check if a number is even.
        /// </summary>
        /// <param name="n">Number to check.</param>
        /// <returns>Evenness of number.</returns>
        private static bool IsEven(int n) {
            return (n & 1) == 0;
        }

        /// <summary>
        /// Check if two numbers have the same sign.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Sign parity of the numbers.</returns>
        private static bool HasOppositeSigns(int a, int b) {
            return (a ^ b) < 0;
        }

        /// <summary>
        /// Increments a value using -~.
        /// ~ Flips the bits of a number.
        /// - Flips the bits and adds 1 (due to 2s complement).
        /// </summary>
        /// <param name="n">Number to increment.</param>
        private static void Increment(ref int n) {
            n = -~n;
        }

        /// <summary>
        /// Swaps the contents of two integer variables using XOR.
        /// </summary>
        /// <param name="a">First variable.</param>
        /// <param name="b">Second variable.</param>
        private static void XorSwap(ref int a, ref int b) {
            // Kalau kamu masih bisa bersama, jangan buang kesempatan itu.
            a ^= b;
            b ^= a;
            a ^= b;
        }

        /// <summary>
        /// Turn off the nth bit of a number.
        /// </summary>
        /// <param name="a">Number.</param>
        /// <param name="bit">Bit position.</param>
        /// <returns>New number with specified bit unset.</returns>
        private static int TurnOffNthBit(int a, int bit) {
            return a & ~(1 << bit);
        }

        /// <summary>
        /// Turn on the nth bit of a number.
        /// </summary>
        /// <param name="a">Number.</param>
        /// <param name="bit">Bit position.</param>
        /// <returns>New number with specified bit set.</returns>
        private static int TurnOnNthBit(int a, int bit) {
            return a | (1 << bit);
        }

        /// <summary>
        /// Check if the nth bit of a number is on.
        /// </summary>
        /// <param name="a">Number.</param>
        /// <param name="bit">Bit position.</param>
        /// <returns>Bit status in number.</returns>
        private static bool IsNthBitSet(int a, int bit) {
            return (a & (1 << bit)) > 0;
        }

        /// <summary>
        /// Toggle the nth bit of a number.
        /// </summary>
        /// <param name="a">Number.</param>
        /// <param name="bit">Bit position.</param>
        /// <returns>New number with specified bit toggled.</returns>
        private static int ToggleNthBit(int a, int bit) {
            return a ^ (1 << bit);
        }

        /// <summary>
        /// Unsets the rightmost set bit of a number.
        /// </summary>
        /// <param name="n">Number.</param>
        /// <returns>Number with rightmost set bit unset.</returns>
        private static int UnsetRightmostBit(int n) {
            return n & (n - 1);
        }

        /// <summary>
        /// Checks if a number is a power of two.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static bool IsPowerOfTwo(int n) {
            return UnsetRightmostBit(n) == 0 && n > 0;
        }

        /// <summary>
        /// Unset every bit except for the rightmost bit of a number.
        /// </summary>
        /// <param name="n">Number.</param>
        /// <returns>A power of two that denotes where the rightmost bit is.</returns>
        private static int GetPositionOfRightmostBit(int n) {
            return n ^ UnsetRightmostBit(n);
        }

        /// <summary>
        /// Turn an uppercase ASCII letter into a lowercase ASCII letter.
        /// Pre: all inputs are letters.
        /// </summary>
        /// <param name="c">Letter to convert.</param>
        /// <returns>Lowercase letter.</returns>
        private static char ToLowercase(char c) {
            return (char) (c | ' ');
        }

        /// <summary>
        /// Turn a lowercase ASCII letter into an uppercase ASCII letter.
        /// Pre: all inputs are letters.
        /// </summary>
        /// <param name="c">Letter to convert.</param>
        /// <returns>Uppercase letter.</returns>
        private static char ToUppercase(char c) {
            return (char) (c & '_');
        }

        /// <summary>
        /// Invert the case of an ASCII letter.
        /// Pre: all inputs are letters.
        /// </summary>
        /// <param name="c">Letter to convert.</param>
        /// <returns>Letter with the opposite case.</returns>
        private static char InvertCase(char c) {
            return (char) (c ^ ' ');
        }

        /// <summary>
        /// Find the position of the ASCII letter in the alphabet, regardless of case.
        /// </summary>
        /// <param name="c">Letter to query.</param>
        /// <returns>Position in alphabet (1-indexed).</returns>
        private static int FindPositionInAlphabet(char c) {
            return c & 31;
        }

        [Test]
        public void TestIsEven() {
            Assertions.Assert(IsEven(4));
            Assertions.Assert(IsEven(60));
            Assertions.Assert(!IsEven(3));
            Assertions.Assert(!IsEven(51));
        }

        [Test]
        public void TestHasOppositeSigns() {
            Assertions.Assert(HasOppositeSigns(10, -10));
            Assertions.Assert(HasOppositeSigns(-9918, 2147));
            Assertions.Assert(!HasOppositeSigns(23, 27));
            Assertions.Assert(!HasOppositeSigns(-621, -486));
        }

        [Test]
        public void TestIncrement() {
            var v1 = 100;
            var v2 = 15;
            var v3 = -44;

            Increment(ref v1);

            Increment(ref v2);
            Increment(ref v2);

            Increment(ref v3);
            Increment(ref v3);
            Increment(ref v3);

            Assertions.AssertEquals(101, v1);
            Assertions.AssertEquals(17, v2);
            Assertions.AssertEquals(-41, v3);
        }

        [Test]
        public void TestXorSwap() {
            var first = 621;
            var second = 2048;

            XorSwap(ref first, ref second);

            Assertions.AssertEquals(2048, first);
            Assertions.AssertEquals(621, second);
        }

        [Test]
        public void TestTurnOffNthBit() {
            var initialNumber = 0b1111;

            Assertions.AssertEquals(0b1110, TurnOffNthBit(initialNumber, 0));
            Assertions.AssertEquals(0b0111, TurnOffNthBit(initialNumber, 3));
            Assertions.AssertEquals(0b1111, TurnOffNthBit(initialNumber, 4));
        }

        [Test]
        public void TestTurnOnNthBit() {
            var initialNumber = 0b1001;

            Assertions.AssertEquals(0b1011, TurnOnNthBit(initialNumber, 1));
            Assertions.AssertEquals(0b1101, TurnOnNthBit(initialNumber, 2));
            Assertions.AssertEquals(0b11001, TurnOnNthBit(initialNumber, 4));
        }

        [Test]
        public void TestIsBitSet() {
            var testNumber = 0b10001110;

            Assertions.Assert(!IsNthBitSet(testNumber, 0));
            Assertions.Assert(IsNthBitSet(testNumber, 1));
            Assertions.Assert(IsNthBitSet(testNumber, 2));
            Assertions.Assert(IsNthBitSet(testNumber, 3));
            Assertions.Assert(!IsNthBitSet(testNumber, 4));
            Assertions.Assert(!IsNthBitSet(testNumber, 5));
            Assertions.Assert(!IsNthBitSet(testNumber, 6));
            Assertions.Assert(IsNthBitSet(testNumber, 7));
        }

        [Test]
        public void TestToggleNthBit() {
            var testNumber = 0;

            Assertions.Assert(!IsNthBitSet(testNumber, 2));

            testNumber = ToggleNthBit(testNumber, 2);
            Assertions.Assert(IsNthBitSet(testNumber, 2));

            testNumber = ToggleNthBit(testNumber, 2);
            Assertions.Assert(!IsNthBitSet(testNumber, 2));
        }

        [Test]
        public void TestIsPowerOfTwo() {
            Assertions.Assert(IsPowerOfTwo(1));
            Assertions.Assert(IsPowerOfTwo(4));
            Assertions.Assert(IsPowerOfTwo(16));
            Assertions.Assert(IsPowerOfTwo(64));

            Assertions.Assert(!IsPowerOfTwo(63));
            Assertions.Assert(!IsPowerOfTwo(621));
            Assertions.Assert(!IsPowerOfTwo(513));
            Assertions.Assert(!IsPowerOfTwo(0));
        }

        [Test]
        public void TestGetPositionOfRightmostBit() {
            var n1 = 0b1001;
            var n2 = 0b0000;
            var n3 = 0b10100;
            var n4 = 0b11000;

            Assertions.AssertEquals(0b1, GetPositionOfRightmostBit(n1));
            Assertions.AssertEquals(0, GetPositionOfRightmostBit(n2));
            Assertions.AssertEquals(0b100, GetPositionOfRightmostBit(n3));
            Assertions.AssertEquals(0b1000, GetPositionOfRightmostBit(n4));
        }

        [Test]
        public void TestToLowercase() {
            Assertions.AssertEquals('x', ToLowercase('X'));
            Assertions.AssertEquals('k', ToLowercase('K'));
            Assertions.AssertEquals('c', ToLowercase('C'));
            Assertions.AssertEquals('d', ToLowercase('D'));
        }

        [Test]
        public void TestToUppercase() {
            Assertions.AssertEquals('X', ToUppercase('x'));
            Assertions.AssertEquals('K', ToUppercase('k'));
            Assertions.AssertEquals('C', ToUppercase('c'));
            Assertions.AssertEquals('D', ToUppercase('d'));
        }

        [Test]
        public void TestInvertCase() {
            Assertions.AssertEquals('X', InvertCase('x'));
            Assertions.AssertEquals('k', InvertCase('K'));
            Assertions.AssertEquals('C', InvertCase('c'));
            Assertions.AssertEquals('d', InvertCase('D'));
        }

        [Test]
        public void TestFindPositionInAlphabet() {
            Assertions.AssertEquals(26, FindPositionInAlphabet('z'));
            Assertions.AssertEquals(26, FindPositionInAlphabet('Z'));

            Assertions.AssertEquals(1, FindPositionInAlphabet('a'));
            Assertions.AssertEquals(1, FindPositionInAlphabet('A'));

            Assertions.AssertEquals(5, FindPositionInAlphabet('e'));
            Assertions.AssertEquals(5, FindPositionInAlphabet('E'));

            Assertions.AssertEquals(10, FindPositionInAlphabet('j'));
            Assertions.AssertEquals(10, FindPositionInAlphabet('J'));
        }
    }
}