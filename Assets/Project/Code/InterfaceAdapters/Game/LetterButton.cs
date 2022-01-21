using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterButton : MonoBehaviour
{
   [SerializeField] private string _letter;

   public string GetLetter()
   {
      return _letter;
   }
}
