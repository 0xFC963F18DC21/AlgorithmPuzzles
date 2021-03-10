using System;

namespace NrgteUnit.Assert {
    /// <summary>
    /// Family of assertion methods for testing purposes.
    /// </summary>
    public static class Assertions {
        /// <summary>
        /// A delegate that simulates a non-returning block that takes no arguments.
        /// </summary>
        public delegate void Block();

        /// <summary>
        /// A basic assertion check.
        /// </summary>
        /// <param name="condition">Condition to assert.</param>
        public static void Assert(bool condition) {
            if (!condition) {
                throw new AssertionException("Failed to assert given condition!");
            }
        }

        /// <summary>
        /// Asserts if two objects are equal. Checks both overridden and referential equality.
        /// </summary>
        /// <param name="expected">Expected object.</param>
        /// <param name="actual">Actual object.</param>
        /// <exception cref="AssertionException">Throws if objects are not equal.</exception>
        public static void AssertEquals(object expected, object actual) {
            if (expected.Equals(actual) || expected == actual) return;

            Console.WriteLine($"Expected: {expected}{Environment.NewLine}  Actual: {actual}");
            throw new AssertionException();
        }

        /// <summary>
        /// Assert that execution of a block throws a certain exception or a subtype of that exception.
        /// </summary>
        /// <param name="func">Block to run.</param>
        /// <typeparam name="TE">Exception superclass to catch.</typeparam>
        /// <exception cref="AssertionException">Throws if an exception fails to be caught.</exception>
        public static void AssertThrows<TE>(Block func) where TE : Exception {
            try {
                func();
            } catch (TE) {
                return;
            } catch (Exception e) {
                Console.WriteLine($"Caught {e.GetType()}, expected {typeof(TE)}.");
                throw new AssertionException("Caught an incorrect exception.");
            }

            throw new AssertionException("Failed to catch exception.");
        }
    }
}