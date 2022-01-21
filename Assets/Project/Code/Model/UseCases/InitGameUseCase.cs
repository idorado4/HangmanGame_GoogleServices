using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InitGameUseCase 
{
    public async Task Do(HangmanGame _hangman)
    {
        await _hangman.StartGame();
    }
}
