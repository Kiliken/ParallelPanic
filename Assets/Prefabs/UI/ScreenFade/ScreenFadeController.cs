using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenFadeController : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy;
    Animator animator;
    private bool playerDead = false;
    private bool inTransition = false;


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
}
