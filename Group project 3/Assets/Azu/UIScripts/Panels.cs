using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panels : MonoBehaviour
{
    public GameObject Panel;
    public GameObject pauseMenu;

 public void OpenPanel()
 {
     if(Panel != null)

     {
         Panel.SetActive(true);
         pauseMenu.SetActive(false);
     }
 }

public void Back()
    {
        Panel.SetActive(false);
        pauseMenu.SetActive(true);
    }

 public void QuitGame()
    {
            Application.Quit();
            Debug.Log("Game is exiting");
    }

 public void StartGame()
    {
            SceneManager.LoadScene("VR");
            Debug.Log("Game is reloading");
    }
}
