using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public GameObject Current_Puzzle,Button_Object;
    public GameObject Object_text;
    Puzzle_Piece Puzzlescript;
    Button Buttonscript;
    Text Show_text;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Puzzle") 
        {   
            Object_text.SetActive(true);
            Show_text = Object_text.GetComponent<Text>();
            Show_text.text = "Rotate";
            Current_Puzzle = other.gameObject;
            Puzzlescript = Current_Puzzle.GetComponent<Puzzle_Piece>();
        }
        if (other.gameObject.tag == "Button") 
        {
            Object_text.SetActive(true);
            Show_text = Object_text.GetComponent<Text>();
            Show_text.text = "Press";
            Button_Object = other.gameObject;
            Buttonscript = Button_Object.GetComponent<Button>();
        }
        
    }
    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Puzzle") 
        {
            Current_Puzzle = null;
            Object_text.SetActive(false);
        }
        if (other.gameObject.tag == "Button") 
        {
            Object_text.SetActive(false);
            Button_Object = null;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Current_Puzzle)
            {
                Puzzlescript.Puzzleface++;
                Current_Puzzle.transform.Rotate(0,-90,0);

            }
            if (Button_Object)
            {
                Buttonscript.CheckPuzzle();
            }
        }
    }
}
