using System;
using System.Text;

public class OldPhonePad
{
    // Define the mappings for each number to corresponding letters
    private static readonly string[] keyMappings = new string[]
    {
        "",    // when user presses 0
        "",    // when user presse 1
        "ABC", // 2
        "DEF", // 3
        "GHI", // 4
        "JKL", // 5
        "MNO", // 6
        "PQRS",// 7
        "TUV", // 8
        "WXYZ" // 9
    };

    public static string OldPhonePadMethod(string input)
    {
        StringBuilder result = new StringBuilder();
        StringBuilder currentInput = new StringBuilder();

        input = input.TrimEnd('#');

        return result.ToString();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePadMethod("33#"));
    }
}