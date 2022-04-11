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

        public  AudioMixer audioMixer;


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



    public void SetVolume (float volume)

    {
        audioMixer.SetFloat("volume", volume);
    }

}
