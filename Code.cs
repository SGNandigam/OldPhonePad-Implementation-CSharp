using System;
using System.Collections.Generic;
using System.Text;

public class OldPhone
{
    public static string OldPhonePad(string input)
    {
        if (string.IsNullOrEmpty(input) || !input.EndsWith("#"))
            return ""; // Ensure valid input with a send button

        Dictionary<char, string> keyMap = new Dictionary<char, string>
        {
            {'2', "ABC"}, {'3', "DEF"}, {'4', "GHI"}, {'5', "JKL"},
            {'6', "MNO"}, {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"},
            {'0', " "} // Space for zero key
        };

        StringBuilder output = new StringBuilder();
        char lastChar = '\0';
        int count = 0;

        foreach (char c in input)
        {
            if (c == '#') break; // Stop processing at send
            if (c == '*')
            {
                if (output.Length > 0)
                    output.Remove(output.Length - 1, 1); // Backspace
                continue;
            }
            if (c == ' ')
            {
                lastChar = '\0'; // Reset sequence due to pause
                count = 0;
                continue;
            }
            
            if (c == lastChar)
            {
                count++;
            }
            else
            {
                count = 1;
            }
            
            if (keyMap.ContainsKey(c))
            {
                string letters = keyMap[c];
                char letter = letters[(count - 1) % letters.Length];
                if (c != lastChar) // Avoid duplicate appends for same key press
                {
                    output.Append(letter);
                }
                else
                {
                    output[output.Length - 1] = letter; // Replace last character
                }
            }
            
            lastChar = c;
        }

        return output.ToString();
    }
}

// Test Cases
class Program
{
    static void Main()
    {
        Console.WriteLine(OldPhone.OldPhonePad("33#")); // E
        Console.WriteLine(OldPhone.OldPhonePad("227*#")); // B
        Console.WriteLine(OldPhone.OldPhonePad("4433555 555666#")); // HELLO
        Console.WriteLine(OldPhone.OldPhonePad("8 88777444666*664#")); // TEST
    }
}
