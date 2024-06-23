using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHitBox : MonoBehaviour
{
    public Transform playerSpawn;
    public Transform enemySpawn;
    public GameObject enemy;
    NavMeshAgent monster;

    private void Start()
    {
        monster = GetComponentInParent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = playerSpawn.position;
            enemy.transform.position = enemySpawn.position;
            monster.ResetPath();
        }
        
    }
}
