using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Piece : MonoBehaviour
{
    public Material Color1,Color2,Color3,Color4;
    MeshRenderer mesh;
    public int Puzzleface = 1;
    int random;
    void Start()
    {
        mesh = this.gameObject.GetComponent<MeshRenderer>();
        random = Random.Range(0,4);
        for (int i = random;i > 0; i--)
        {
            Puzzleface ++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Puzzleface >= 5)
        {
            Puzzleface = 1;
        }
        if (Puzzleface == 1)
        {
            mesh.material = Color1;
        } else if (Puzzleface == 2)
        {
            mesh.material = Color2;
        } else if (Puzzleface == 3)
        {
            mesh.material = Color3;
        } else if (Puzzleface == 4)
        {
            mesh.material = Color4;
        }
    }
}
