using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent monster;
    public GameObject player;
    private void Start()
    {
        monster = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        monster.SetDestination(player.transform.position);
    }
}
