namespace Aoc23;

public class Day1Part1Tests
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    [InlineData("24", 24)]
    public async Task Line1(string input, int expected)
    {
        var result = Day1Part1.LineParser(input);
        result.Should().Be(expected);
    }

    [Fact]
    public void Part1Sample()
    {
        var input = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";
        var result = input.Split("\n").Select(Day1Part1.LineParser).Sum();
        result.Should().Be(142);
    }

    [Fact]
    public void Part1Full()
    {
        var input = File.ReadAllText("Day1\\input.txt");
        var result = input.Split("\n").Select(Day1Part1.LineParser).Sum();
        result.Should().Be(53386);
    }

    public class Day1Part1
    {
        public static int LineParser(string input)
        {
            var digits = input.Where(char.IsDigit);
            return int.Parse(digits.First().ToString() + digits.Last());
        }
    }
}