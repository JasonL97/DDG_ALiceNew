using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour {

    public float speed = 20.0f;
    public float speed1 = 20.0f;
    public float minDist = 1f;
    public Transform[] spawnpoints;
    public float minDistance = 3;
    public float maxDistance = 10; 
    public Transform target;
    public GameObject player;
    

    // Use this for initialization
    void Start()
    {
        // if no target specified, assume the player
        //if (target == null)
        //{

        //    if (GameObject.FindWithTag("Player") != null)
        //    {
        //        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //    }
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
        if (target == null)
            return;
        float distance1 = Vector3.Distance(transform.position, player.transform.position);

        // face the target
        transform.LookAt(target);

        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);

        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (distance > minDist)

            transform.position += transform.forward * speed1 * Time.deltaTime;
        if (distance1 > maxDistance)
        {
            MoveToCloserSpawnpoint();
        }


        Player pl = player.GetComponent<Player>();
        //if (pl.invisible == true)
        //{
        //    speed1 = 0;
        //}

        //if (pl.invisible == false)
        //{
        //    speed1 = speed;
        //}

    }

    // Set the target of the chaser
    public void SetTarget(Transform newTarget)
    {

        target = newTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("game_over");
        }
    }
    void MoveToCloserSpawnpoint()
    {
        // This chooses the first spawnpoint that's within range:
        foreach (var spawnpoint in spawnpoints)
        {
            float distance1 = Vector3.Distance(spawnpoint.position, player.transform.position);
            if (minDistance < distance1 && distance1 < maxDistance)
            {
                transform.position = spawnpoint.position;
                break;
            }
        }
    }

}
