using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent monster;
    public GameObject player;
    public float triggerDistance;
    bool hasLineOfSight = false;
    public WorldBounds bounds;
    LayerMask mask = -1;

    public float playerDistance;
    public bool canMove = true;
    [SerializeField] private Transform enemySpawn;
    public Transform trapPos;
    public bool moveToTrap = false;
    private bool trapPosSet = false;
    

    private void Start()
    {
        monster = GetComponent<NavMeshAgent>();
    }


    void FixedUpdate()
    {
        if(canMove){
            if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out RaycastHit ray, triggerDistance, mask, QueryTriggerInteraction.Ignore))
            {
                hasLineOfSight = ray.collider.CompareTag("Player");
                if (hasLineOfSight)
                {
                    if(moveToTrap){
                        monster.speed = 2.5f;
                        monster.angularSpeed = 120;
                        moveToTrap = false;
                    }
                    monster.SetDestination(player.transform.position);
                }
            }

            if(moveToTrap){
                if(!trapPosSet){
                    monster.SetDestination(trapPos.position);
                    monster.speed = 7;
                    monster.angularSpeed = 500;
                    trapPosSet = true;
                }
                float trapDist = Vector3.Distance(transform.position, trapPos.position);
                if(trapDist <= 2){
                    monster.speed = 2.5f;
                    monster.angularSpeed = 120;
                    moveToTrap = false;
                }
            }
            else if (!monster.hasPath)
            {
                Vector3 min = bounds.min.position;
                Vector3 max = bounds.max.position;

                Vector3 randomPos = new Vector3(
                    Random.Range(min.x, max.x),
                    Random.Range(min.y, max.y),
                    Random.Range(min.z, max.z)
                    );
                monster.SetDestination(randomPos);
                //Debug.Log(Vector3.Distance(monster.transform.position, player.transform.position));
                /*if (Vector3.Distance(monster.transform.position, player.transform.position) < 20f)
                {
                    Vector3 min = bounds.min.position;
                    Vector3 max = bounds.max.position;

                    Vector3 randomPos = new Vector3(
                        Random.Range(min.x, max.x),
                        Random.Range(min.y, max.y),
                        Random.Range(min.z, max.z)
                        );
                    monster.SetDestination(randomPos);
                    Debug.Log("Wandering");
                }
                else
                {
                    monster.SetDestination(player.transform.position);
                    Debug.Log("Chasing player");
                }*/
            }
        }
        
        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(System.Math.Round((31 - playerDistance)/31, 2));
    }

    public void Respawn(){
        monster.Warp(enemySpawn.position);
        //transform.position = enemySpawn.position;
        monster.ResetPath();
        
    }

}
