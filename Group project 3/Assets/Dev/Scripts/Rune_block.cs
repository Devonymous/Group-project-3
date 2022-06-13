using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune_block : MonoBehaviour
{
    public int Puzzleface = 1;
    int random;
    void Start()
    {
        random = Random.Range(0, 4);
        for (int i = random; i > 0; i--)
        {
            transform.Rotate(0, 90, 0);
            Puzzleface++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Puzzleface >= 5)
        {
            Puzzleface = 1;
        }
    }
}
