using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject settingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(1).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();
        transform.GetChild(2).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();
        transform.GetChild(3).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == null && Input.GetAxisRaw("Vertical") != 0){
            EventSystem.current.SetSelectedGameObject(transform.GetChild(1).gameObject);
        }
        
    }

    public void ResumeGame(){
        gameManager.ResumeGame();
    }

    public void OpenSettings(){
        // set active to panel
        settingsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
    public void LoadTitle(){
        GameManager.gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }

    void OnEnable(){
        EventSystem.current.SetSelectedGameObject(transform.GetChild(1).gameObject);
    }
}
