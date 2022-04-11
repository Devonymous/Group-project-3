using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
    // Start is called before the first frame update
    
    {
        public bool isPaused;

        public GameObject pauseMenu;
        public GameObject pauseBG;


    void Start()
        {
            pauseMenu.SetActive(false);
            pauseBG.SetActive(false);
        }
   
    void Update()
        {
           if(Input.GetKeyDown(KeyCode.Escape))
           {
               if(isPaused)
               {
                   ResumeGame();
               }
               else 
               {
                   PauseGame();
               }
           }
        }

    public void PauseGame()
        {
            pauseMenu.SetActive(true);
            pauseBG.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            pauseBG.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

}
