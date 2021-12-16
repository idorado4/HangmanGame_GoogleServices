using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordEncryptor
{
    //https://en.wikipedia.org/wiki/XOR_cipher
    //http://www.unity3dtechguru.com/2021/03/data-encryption-decryption-unity-c.html
    //ENCRIPTADOR DE CONTRASEÑAS CON UNA KEY PARA COMPARAR BITS
    
    public string XOREncryptDecrypt(string inputData)
    {
        string outSb = "";
        for (int i = 0; i < inputData.Length; i++)
        {     
            //Here 47747891 is key for Encrypt/Decrypt, You can use any int number
            char ch = (char)(inputData[i] ^ 47747891);
            outSb += ch;
        }
        return outSb;
    }
    
    
}
