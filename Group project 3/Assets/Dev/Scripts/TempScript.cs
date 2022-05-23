using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour
{
    public GameObject[] Puzzle_items;
    bool Effect = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Effect = !Effect;
            if (Effect == true) {
                for (int i = 0; i < Puzzle_items.Length; i++)
                {
                    Puzzle_items[i].SetActive(true);
                }
            } else {
                for (int i = 0; i < Puzzle_items.Length; i++)
                {
                    Puzzle_items[i].SetActive(false);
                }
            }
        }
    }
}
