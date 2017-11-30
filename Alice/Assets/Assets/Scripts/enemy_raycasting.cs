using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_raycasting : MonoBehaviour {

    protected float rotation = 120;
    public float distanceCheck = 200f;
    public Transform target;
    public float minDistance = 3;
    public float maxDistance = 10;
    public float speed = 20.0f;
    public float speed1 = 20.0f;
    public float minDist = 1f;
    public GameObject player;

    void Update()
    {
        rotation += 36.0f * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, rotation, 0);

        RaycastHit hit;
        Ray playerRay = new Ray(transform.position, Vector3.forward);
        if(Physics.Raycast(playerRay, out hit, distanceCheck))

        {

            if (hit.collider.tag == "Player")

            {
                ChaseTarget();

            }

        }
    }
    public void SetTarget(Transform newTarget)
    {

        target = newTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("game_over");
        }
    }
    void ChaseTarget()
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


}