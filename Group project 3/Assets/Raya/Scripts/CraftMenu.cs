using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftMenu : MonoBehaviour
{
    public GameObject Cam;
    public GameObject craftingMenu;
    public bool Open_inv = false;

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
            Cam.SetActive(false);
            craftingMenu.SetActive(true);
        } else if (Open_inv == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cam.SetActive(true);
            craftingMenu.SetActive(false);
        }
    }
}
