using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Puzzle_Piece Puzzle1,Puzzle2,Puzzle3;
    public Moving_platform Platform1,Platform2,Platform3;

    public void CheckPuzzle()
    {
        if (Puzzle1.Puzzleface == 1 && Puzzle2.Puzzleface == 1 && Puzzle3.Puzzleface == 1)
        {
            Platform1.Move = true;
            Platform2.Move = true;
            Platform3.Move = true;
        }
    }
}
