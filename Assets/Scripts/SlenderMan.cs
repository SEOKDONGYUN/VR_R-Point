using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlenderMan : MonoBehaviour
{
    Camera mainCamera;

    private NavMeshAgent enemy;
    public GameObject player;
    public bool isEnemySeen;


    // Start is called before the first frame update
    void Start()
    { 
        mainCamera = Camera.main;
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //If we dont look at him for x sec or we are too far, he changes its position after x sec
        if(PostProcessBzz.timeNotLooking > 8)
        {
            PostProcessBzz.timeNotLooking = 0;
            Spawn();
        }

        //Keep on facing player
        transform.LookAt(new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z));

        if (isEnemySeen)
        {
            enemy.GetComponent<NavMeshAgent>().enabled = false;
        }
        else
        {
            enemy.GetComponent<NavMeshAgent>().enabled = true;
            enemy.SetDestination(player.transform.position);
        }
    }

    void Spawn()
    {
        RaycastHit hit;
        float randomDistance = Random.Range(10, 20);
        float randomAngle = Random.Range(0, 360);

        Vector3 raySpawnPosition = mainCamera.transform.position
                    + new Vector3(randomDistance * Mathf.Cos(randomAngle), 50, randomDistance * Mathf.Sin(randomAngle));

        // note that the ray starts at 100 units
        Ray ray = new Ray(raySpawnPosition, Vector3.down);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                // this is where the gameobject is actually put on the ground
                transform.position = hit.point;
            }
        }
    }

    private void OnBecameVisible()
    {
        isEnemySeen = true;
    }

    private void OnBecameInvisible()
    {
        isEnemySeen = false;
    }
}
