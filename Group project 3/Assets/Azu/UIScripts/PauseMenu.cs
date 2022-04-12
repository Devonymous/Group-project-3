using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
    // Start is called before the first frame update
    
    {
        public bool isPaused;

        public GameObject pauseMenu;
        public GameObject pauseBG;

        public  AudioSource audioMixer;
        public GameObject Camera;


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

            isPaused = true;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Camera.SetActive(false);
        }
    public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            pauseBG.SetActive(false);
    
            isPaused = false;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Camera.SetActive(true);
        }



    public void SetVolume (float volume1)

    {
        audioMixer.volume=volume1;
    }

}
