using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class WinScreenScript : MonoBehaviour
{
    public GameManager gameManager;
    GameObject winScreen1;
    GameObject winScreen2;
    public ScreenFadeController screenFade1;
    public ScreenFadeController screenFade2;
    public BGM bgm;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(2).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();
        transform.GetChild(3).GetComponent<ButtonScript>().audioSource = gameManager.gameObject.GetComponent<AudioSource>();
        winScreen1 = transform.GetChild(0).gameObject;
        winScreen2 = transform.GetChild(1).gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWinScreen(){
        EventSystem.current.SetSelectedGameObject(transform.GetChild(2).gameObject);
        if(GameManager.winner == 1){
            winScreen1.SetActive(true);
        }
        else if(GameManager.winner == 2){
            winScreen2.SetActive(true);
        }
        bgm.StopMusic();
        audioSource.Play();
    }

    public void ReloadGame(){
        audioSource.enabled = false;
        GameManager.winner = 0;
        screenFade1.reloadGame = true;
        screenFade1.FadeOutMenu();
        screenFade2.FadeOutMenu();
    }

    public void ExitGame(){
        audioSource.enabled = false;
        GameManager.winner = 0;
        screenFade1.exitGame = true;
        screenFade1.FadeOutMenu();
        screenFade2.FadeOutMenu();
    }
}
