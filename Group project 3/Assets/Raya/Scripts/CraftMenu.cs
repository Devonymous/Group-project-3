using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftMenu : MonoBehaviour
{
    public GameObject Cam;
    public GameObject craftingMenu;
    public bool Open_inv = false;
   // private GameObject player;


    private void Start()
    {
       // player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            OpenCraftMenu();
        }
        
    }

    public void OpenCraftMenu()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Open_inv = !Open_inv;     
        }
        if (Open_inv == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //Time.timeScale = 0f;
            Cam.SetActive(false);
            craftingMenu.SetActive(true);
        } else if (Open_inv == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            //Time.timeScale = 0f;
            Cam.SetActive(true);
            craftingMenu.SetActive(false);
        }
    }
}
