using System;
using System.Text;
public static class OldPhonePad
{
    // key  mappings for numeric digits on the phone keypad
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

    // main method to process the input string
    public static string OldPhonePadMethod(string input)
    {
        StringBuilder result = new StringBuilder();

        // temp builder to hold the current key sequence being processed
        StringBuilder currentInput = new StringBuilder();
        char lastKey = '\0'; // #

        input = input.TrimEnd('#'); // ends on #

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            // space
            if (currentChar == ' ')
            {
                MoveInputToResult(currentInput, result);
                lastKey = '\0'; // reset sequence
            }

            // backspace
            else if (currentChar == '*')
            {
                if (currentInput.Length > 0)
                {
                    // something in the current sequence so remove the last character from the sequence
                    currentInput.Length--;
                }
                else
                {
                    // otherwise remove the last character from the result
                    result.Length--;
                }
            }
            else
            {
                if (currentChar == lastKey)
                {
                    // a same key was pressed consecutively, add it
                    currentInput.Append(currentChar);
                }
                else
                {
                    MoveInputToResult(currentInput, result);
                    currentInput.Append(currentChar); // start a new sequence with the current key
                }
                lastKey = currentChar; // update lastKey to the current key
            }
        }

        if (currentInput.Length > 0)
        {
            // for remaining characters in currentInput
            result.Append(MapKeys(currentInput.ToString()));
        }

        return result.ToString(); // final result

        static void MoveInputToResult(StringBuilder currentInput, StringBuilder result)
        {
            if (currentInput.Length > 0)
            {
                // contains a sequence.
                result.Append(MapKeys(currentInput.ToString())); // map it to the corresponding character
                currentInput.Clear(); // and clear
            }
        }

        static char MapKeys(string sequence)
        {
            if (string.IsNullOrEmpty(sequence)) return ' ';

            char key = sequence[0];

            if (key == '0' || key == '1') return ' ';

            int keyNumber = key - '0'; // make the char int type
            if (keyNumber < 2 || keyNumber > 9) return ' ';

            int pressCount = sequence.Length;
            string letters = keyMappings[keyNumber];

            if (pressCount <= letters.Length)
            {
                return letters[pressCount - 1]; // the actual mapping for 2-9 numeric keys
            }

            // If the presses exceed the number of letters ( like pressing '2' five times),
            //  cycle through the available letters only
            return letters[pressCount % letters.Length];
        }
    }
}