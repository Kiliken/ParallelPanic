using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHitBox : MonoBehaviour
{
    public ScreenFadeController screenFade;
    public Transform playerSpawn;
    public Transform enemySpawn;
    public GameObject enemy;
    [SerializeField] GameObject playerParticle;
    [SerializeField] GameObject deathParticle;
    NavMeshAgent monster;
    AudioSource audioSource;

    private void Start()
    {
        monster = GetComponentInParent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            screenFade.FadeOut(true);
            audioSource.Play();
            GameObject dp = Instantiate(deathParticle, playerParticle.transform.position, deathParticle.transform.rotation);
            Destroy(dp, 1f);
            // other.transform.position = playerSpawn.position;
            // enemy.transform.position = enemySpawn.position;
            // monster.ResetPath();
        }
        
    }
}
