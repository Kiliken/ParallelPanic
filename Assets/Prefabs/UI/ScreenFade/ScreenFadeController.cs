using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScreenFadeController : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy;
    Animator animator;
    public WinScreenScript winScreen;

    private bool playerDead = false;
    private bool inTransition = false;
    public bool exitGame = false;
    public bool reloadGame = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void FadeOut(bool dead){
        if(!inTransition){
            animator.SetTrigger("FadeOut");
            player.canMove = false;
            playerDead = dead;
            if(playerDead)
                enemy.canMove = false;

            inTransition = true;
        }
    }

    public void FadeOutMenu(){
        animator.SetTrigger("FadeOutM");
        player.canMove = false;
        enemy.canMove = false;
        inTransition = true;
    }


    public void OnFadeOutComplete(){
        player.Respawn();
        if(playerDead)
            enemy.Respawn();
        playerDead = false;
        inTransition = false;
    }


    public void OnFadeInComplete(){
        player.canMove = true;
        enemy.canMove = true;
    }


    public void OnFadeOutMComplete(){
        if(exitGame){
            SceneManager.LoadScene("Title");
        }
        else if(reloadGame){
            SceneManager.LoadScene("FinalLevel");
        }
        else{
            player.Respawn();
            enemy.Respawn();
            winScreen.gameObject.SetActive(true);
            winScreen.ShowWinScreen();
            animator.SetTrigger("FadeInM");
        }
        
        inTransition = false;
    }
}
