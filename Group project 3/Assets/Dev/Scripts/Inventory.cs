using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inven;
    bool Open_inv = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inven();
        }
    }

    public void Inven()
    {
        if (Open_inv == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            inven.SetActive(false);
            Open_inv = false;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            inven.SetActive(true);
            Open_inv = true;
            Time.timeScale = 0f;
        }
    }
}
