using Algorithms.DynamicProgramming;

namespace Algorithms.UnitTests.DynamicProgramming;

public class LongestCommonSubstringTests
{
    [Test]
    public void LCS_Finds_Longest_Common_Substring()
    {
        // Arrange
        const string word1 = "FISH";
        const string word2 = "FIST";
        
        // Act
        var grid = LongestCommonSubstring.Find(word1, word2);
        var nonZeroCells = grid.Cast<Cell>().Where(c => c.Value > 0).OrderBy(c => c.Value).ToArray();
        var substring = string.Concat(nonZeroCells.Select(c => c.Character));
        var maxCellValue = nonZeroCells.Last().Value; // Because nonZeroCells is already ordered in ascending order
        
        // Assert
        Assert.That(maxCellValue, Is.EqualTo(3));
        Assert.That(substring, Is.EqualTo("FIS"));
    }
}