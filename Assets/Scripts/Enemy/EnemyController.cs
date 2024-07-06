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
    

    private void Start()
    {
        monster = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out RaycastHit ray, triggerDistance))
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
            if (hasLineOfSight)
            {
                monster.SetDestination(player.transform.position);
            }
        }

        if (!monster.hasPath)
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

}
