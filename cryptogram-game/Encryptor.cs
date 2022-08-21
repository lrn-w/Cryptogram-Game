
using System;
using System.Collections.Generic;
using System.Linq;

public class Encryptor
{
    private static readonly char[] OriginalAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    private static readonly char[] ShuffledAlphabet = ShuffleCharArray((char[])OriginalAlphabet.Clone());

    private static char[] ShuffleCharArray(IList<char> charArray)
    {
        var shuffledArray = new char[charArray.Count];

        var random = new Random();
        for (var i = charArray.Count; i >= 1; i--)
        {
            var randomNumber = random.Next(1, i + 1) - 1;
            shuffledArray[i - 1] = charArray[randomNumber];
            charArray[randomNumber] = charArray[i - 1];
        }

        return shuffledArray;
    }

    public static char[] Encrypt(IEnumerable<char> charArray)
    {
        var encryptedString = string.Empty;
        foreach (var currentChar in charArray)
        {
            if (OriginalAlphabet.Contains(char.ToUpper(currentChar)))
            {
                var position = Array.IndexOf(OriginalAlphabet, char.ToUpper(currentChar));

                encryptedString += ShuffledAlphabet.ElementAt(position);
            }
            else
            {
                encryptedString += currentChar;
            }
        }

        return encryptedString.ToCharArray();
    }

    public static char[] GenerateUserStartingText(IEnumerable<char> charArray)
    {
        var userStartingText = string.Empty;
        foreach (var currentChar in charArray)
        {
            if (OriginalAlphabet.Contains(char.ToUpper(currentChar)))
            {
                userStartingText += " ";
            }
            else
            {
                userStartingText += currentChar;
            }
        }

        return userStartingText.ToCharArray();
    }
}
