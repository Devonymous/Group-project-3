using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzlechecker : MonoBehaviour
{
    public Puzzle_Piece Switch1,Switch2,Switch3,Switch4;
    public GameObject Door, roof;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Switch1.Puzzleface == 1  & Switch2.Puzzleface == 1 & Switch3.Puzzleface == 1 & Switch4.Puzzleface == 1)
        {
            Destroy(Door);
            Destroy(roof);
        }
    }
}
