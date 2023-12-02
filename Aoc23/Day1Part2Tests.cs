namespace Aoc23;

using System.Globalization;
using FluentAssertions;
using Xunit;

public class Day1Part2Tests
{
    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    [InlineData("8qxjdsspgn\n", 88)]
    [InlineData("onetwo\n", 12)]
    [InlineData("onetwothreefourfivesixseveneightnine\n", 19)]
    [InlineData("ckmb52fldxkseven3fkjgcbzmnr7\n", 57)]
    [InlineData("gckhqpb6twoqnjxqplthree2fourkspnsnzxlz1\n", 61)]
    [InlineData("3nine6five1\n", 31)]
    [InlineData("eighttwothree\n", 83)]
    [InlineData("eightthree\n", 83)]
    [InlineData("sevennine\n", 79)]
    [InlineData("oneight\n", 18)]
    [InlineData("3lpchjfgbhzjbqggsfoursixseven\n", 37)]
    [InlineData("zoneight47five5sixjxd74\n", 14)]
    public async Task Line1(string input, int expected)
    {
        var result = Day1Part2.LineParser(input);
        result.Should().Be(expected);
    }

    [Fact]
    public void Part2Sample()
    {
        var input =
            "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen";
        var result = input.Split("\n").Select(Day1Part2.LineParser).Sum();
        result.Should().Be(281);
    }

    [Fact]
    public void Part2Full()
    {
        var input = File.ReadAllText("Day1\\input.txt");
        var strings = input.Split("\n");
        int total = strings.Sum(Day1Part2.LineParser);


        total.Should().Be(53312);
    }

    public class Day1Part2
    {
        private static string[] numberParts = {
            "somethingthatwillnevermatch",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"

        };
        public static int LineParser(string input)
        {
            List<(int position, string part)> lowestParts = (from part in numberParts
                let indexOf = input.IndexOf(part, StringComparison.InvariantCultureIgnoreCase)
                where indexOf != -1
                select (indexOf, part)).ToList();
            List<(int position, string part)> highestParts = (from part in numberParts
                let indexOf = input.LastIndexOf(part, StringComparison.InvariantCultureIgnoreCase)
                where indexOf != -1
                select (indexOf, part)).ToList();

            var parts = lowestParts.Concat(highestParts).ToList();

            var first = parts.MinBy(x => x.position);
            var last = parts.MaxBy(x => x.position);
            first.part = ConvertToNumeric(first.part);
            last.part = ConvertToNumeric(last.part);
            return Convert.ToInt32(first.part + last.part);
        }

        private static string ConvertToNumeric(string firstPart)
        {
            if (int.TryParse(firstPart, out _))
                return firstPart;
            var convertToNumeric = Array.FindIndex(numberParts,
                np => np.Equals(firstPart, StringComparison.CurrentCultureIgnoreCase)).ToString();
            return convertToNumeric;
        }
    }
}