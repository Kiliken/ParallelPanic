using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    AudioSource audioSource;
    public AudioSource bgm;
    public AudioSource Enemy1Voice;
    public AudioSource Enemy2Voice;
    public static bool gamePaused = false;

    void Awake(){
        pauseMenu.GetComponent<PauseMenu>().gameManager = this.GetComponent<GameManager>();
        settingsMenu.GetComponent<SettingsMenu>().gameManager = this.GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause")){
            if(!gamePaused){
                PauseGame();
            }
            else{
                ResumeGame();
            }

        }
        
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        //AudioListener.pause = true;
        bgm.Pause();
        Enemy1Voice.Pause();
        Enemy2Voice.Pause();
        gamePaused = true;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        //AudioListener.pause = false;
        bgm.UnPause();
        Enemy1Voice.UnPause();
        Enemy2Voice.UnPause();
        gamePaused = false;
    }
}
