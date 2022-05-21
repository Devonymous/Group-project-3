using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
    // Start is called before the first frame update
    
    {
        public bool isPaused;

        public GameObject pauseMenu;
        public GameObject pauseBG;

        public  AudioSource audioMixer;
        public GameObject Camera;
        public CinemachineFreeLook SensCam;
        public Slider Volume,sens;


    void Start()
        {
            Volume.value = audioMixer.volume;
            sens.value = SensCam.m_YAxis.m_MaxSpeed * 250;
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
    
    public void Quit()
    {
        Application.Quit();
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


    public void SetSens (float sens) 
    {
        SensCam.m_XAxis.m_MaxSpeed = sens / 3.5f;
        SensCam.m_YAxis.m_MaxSpeed = sens / 250;
    }
    public void SetVolume (float volume1)

    {
        audioMixer.volume=volume1;
    }

}
