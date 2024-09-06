using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    public EnemyController enemy;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.canMove){
            animator.SetFloat("EnemyDist", enemy.playerDistance);
        }
        
    }

    public void PlaySFX(){
        if(SettingsMenu.sfx_on && GameManager.winner == 0)
            audioSource.Play();
    }
}
