# Old Phone Keypad Input Reader

## Overview

This project simulates the functionalty of an old mobile phone keypad, where each number corresponds to a set of characters. 
The program accepts an input string representing key presses on the keypad, with the number of consecutive presses determining the character selected and map these "presses" to compile the output. 

This solution also handles edge cases like backspace (*) and send (#) characters.

## Problem Description:

The goal is to implement a method that converts a series of keypresses into a string based on the old mobile phone keypads.

| Key | Letters        |
|-----|----------------|
| 2   | A, B, C        |
| 3   | D, E, F        |
| 4   | G, H, I        |
| 5   | J, K, L        |
| 6   | M, N, O        |
| 7   | P, Q, R, S     |
| 8   | T, U, V        |
| 9   | W, X, Y, Z     |
| 0   | (no letters)   |
| 1   | (no letters)   |


### How it works:

- Pressing **2** once gives you **A**, twice gives you **B**, and three times gives you **C**.
- Pressing **2** then adding a space in the input (representing a pause) then pressing **2** twice will give you **AB**
- **0** and **1** do not have any associated letters.
- Adding * to the input will decrement the count of the prior key press (number sequence) by 1, example: **22** gives you **B**, **22*** gives you **A**

# Installation and Usage

## Clone the repository:

```bash
git clone https://github.com/yourusername/OldPhoneKeypad.git
```

1 - Open the project in Visual Studio or your preferred C# editor.

2 - Run unit tests as is or add your own test cases in the OldPhoneKeypadInputReaderTests project.

