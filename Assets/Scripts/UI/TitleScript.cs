using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    private void Start()
    {
        //Cursor.visible = false;
    }


    // Start is called before the first frame update
    public void LoadGame() {
        SceneManager.LoadScene("FinalLevel");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
