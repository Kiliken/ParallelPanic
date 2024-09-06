using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] Transform playerSpawn;
    [SerializeField] Transform newPlayerSpawn;

    [Header("Enemy")]
    [SerializeField] Transform enemySpawn;
    [SerializeField] Transform newEnemySpawn;

    [Header("Other")]
    [SerializeField] Animator doorAnim;
    [SerializeField] AudioSource audioSource;
    bool active;

    void Start()
    {
        active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && active)
        {
            active = false;
            doorAnim.SetBool("open", false);
            if (SettingsMenu.sfx_on)
                audioSource.Play();
            playerSpawn.position = newPlayerSpawn.position;
            enemySpawn.position = newEnemySpawn.position;
        }
           
    }
}
