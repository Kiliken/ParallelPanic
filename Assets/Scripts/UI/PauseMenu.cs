using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame(){
        gameManager.ResumeGame();
    }

    public void OpenSettings(){
        // set active to panel
    }
    
    public void LoadTitle(){
        SceneManager.LoadScene("Title");
    }

    
}
