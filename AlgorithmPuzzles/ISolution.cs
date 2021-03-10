namespace AlgorithmPuzzles {
    /// <summary>
    /// Interface implemented by all solution classes.
    /// </summary>
    public interface ISolution {

        /// <summary>
        /// Get the name of the solution, pre-formatted for printing.
        /// </summary>
        /// <returns>Formatted name of solution.</returns>
        string GetName();
    }
}