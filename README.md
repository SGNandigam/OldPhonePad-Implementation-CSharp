# OldPhonePad-Implementation-c#
This project implements a C# method OldPhonePad to simulate an old mobile phone keypad's behavior. The function takes a string input and converts it into a corresponding text output based on keypress rules.


***Features***
1. Correctly maps numeric keys (2-9) to their respective alphabetic characters.
2. Handles repeated key presses to cycle through available characters.
3. Supports a backspace (*) feature to delete the last character.
4. Recognizes pauses (' ') to differentiate consecutive characters from the same key.
5. Ends processing when encountering the send button (#).

***Usage***
1. *Function Signature:* public static string OldPhonePad(string input)
2. *Parameter:* input (string): A sequence of numeric key presses representing text input, ending with #.
3. *Returns:* A decoded string representing the final text message.

***Example Inputs & Outputs***
- Input: 33# -> Output: E
- Input: 227*# -> Output: B
- Input: 4433555 555666# -> Output: HELLO

***Implementation Details***
*Key Mapping:* The function uses a dictionary to map keys to corresponding letters.
*Logic Flow:* 
1. Iterate through input characters while maintaining:
  - lastChar to track the last pressed key.
  - count to determine which letter in the sequence should be selected.
2. Handle special cases:
  - '*' (Backspace): Removes the last added character.
  - ' ' (Pause): Resets the letter selection sequence.
  - '#' (Send): Ends processing.
3. Select letters appropriately based on consecutive key presses.

***Testing***

A test suite is included with sample test cases:

Console.WriteLine(OldPhone.OldPhonePad("33#")); // Output: E  
Console.WriteLine(OldPhone.OldPhonePad("227*#")); // Output: B  
Console.WriteLine(OldPhone.OldPhonePad("4433555 555666#")); // Output: HELLO  
Console.WriteLine(OldPhone.OldPhonePad("8 88777444666*664#")); // Output: TEST 
