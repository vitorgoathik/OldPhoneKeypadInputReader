using System;
using System.Text;
public class OldPhonePad
{
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
        char lastKey = '\0';

        input = input.TrimEnd('#');

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == ' ')
            {
                if (currentInput.Length > 0)
                {
                    result.Append(MapKeys(currentInput.ToString()));
                    currentInput.Clear();
                }
                lastKey = '\0';
            }
            else
            {
                if (currentChar == lastKey)
                {
                    currentInput.Append(currentChar);
                }
                else
                {
                    if (currentInput.Length > 0)
                    {
                        result.Append(MapKeys(currentInput.ToString()));
                        currentInput.Clear();
                    }
                    currentInput.Append(currentChar);
                }
                lastKey = currentChar;
            }
        }

        if (currentInput.Length > 0)
        {
            result.Append(MapKeys(currentInput.ToString()));
        }

        return result.ToString();
    }

    private static char MapKeys(string sequence)
    {
        if (string.IsNullOrEmpty(sequence)) return ' ';

        char key = sequence[0];

        if (key == '0' || key == '1') return ' ';

        int keyNumber = key - '0';
        if (keyNumber < 2 || keyNumber > 9) return ' ';

        int pressCount = sequence.Length;
        string letters = keyMappings[keyNumber];

        if (pressCount <= letters.Length)
        {
            return letters[pressCount - 1];
        }

        return letters[pressCount % letters.Length];
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePadMethod("33#"));              // Output: e
        Console.WriteLine(OldPhonePadMethod("227*#"));            // Output: b
        Console.WriteLine(OldPhonePadMethod("4433555 555666#"));  // Output: hello
        Console.WriteLine(OldPhonePadMethod("8 88777444666*664#")); // Output: ????? 
    }
}