using Algorithms.DynamicProgramming;

namespace Algorithms.UnitTests.DynamicProgramming;

public class LongestCommonSubsequenceTests
{
    [Test]
    public void LCS_Finds_Longest_Common_Subsequence()
    {
        // Arrange
        const string word1 = "AAACCGTGAGTTATTCGTTCTAGAA";
        const string word2 = "CACCCCTAAGGTACCTTTGGTTC";

        // Act
        var grid = LongestCommonSubsequence.Find(word1, word2);
        var subsequence = LongestCommonSubsequence.GetLongestCommonSubsequence(grid);
        var subsequenceLength = grid.Cast<Cell>().MaxBy(c => c.Value)!.Value;

        // Assert
        Assert.That(subsequence, Is.EqualTo("ACCTAGTATTGTTC"));
        Assert.That(subsequenceLength, Is.EqualTo(14));
    }
}