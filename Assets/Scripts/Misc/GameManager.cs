using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        
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
        AudioListener.pause = true;
        gamePaused = true;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        gamePaused = false;
    }
}
