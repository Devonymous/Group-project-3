using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftMenu : MonoBehaviour
{
    public GameObject Cam;
    public GameObject craftingMenu;
   // private GameObject player;


    private void Start()
    {
       // player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.Confined;
            //Time.timeScale = 0f;
            //player.SetActive(false);
            //craftingMenu.SetActive(true);
            OpenCraftMenu();
        }
    }

    public void OpenCraftMenu()
    {
        if (craftingMenu != null)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            //Time.timeScale = 0f;
            Cam.SetActive(false);
            craftingMenu.SetActive(true);
        }
    }
}
