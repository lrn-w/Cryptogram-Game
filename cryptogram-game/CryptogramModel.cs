
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class CryptogramModel : MonoBehaviour
{
    // The Encrypted Version of the Cryptogram
    public char[] EncryptedText { get; private set; }

    // The original Decrypted version of the Cryptogram
    public char[] OriginalDecryptedText { get; private set; }

    // The starting text that the user will use to decrypt the Cryptogram
    public char[] StartingUserDecryptedText { get; private set; }

    public bool CryptogramSolved(IEnumerable<char> userDecryptedText)
    {
        return userDecryptedText.SequenceEqual((OriginalDecryptedText));
    }

    internal void Initialize(string levelText)
    {
        var upperCharArrayLevelText = levelText.Select(char.ToUpper).ToArray();

        // Sets the OriginalDecryptedText to the levels unEncryptedText
        OriginalDecryptedText = upperCharArrayLevelText;

        // Encrypts the level text
        EncryptedText = Encryptor.Encrypt(upperCharArrayLevelText);

        StartingUserDecryptedText = Encryptor.GenerateUserStartingText(upperCharArrayLevelText);
    }
}
