
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    public VirtualJoystick joystick;
    public Rigidbody thisRigidbody;
    public GameObject mainCamera;
    public Vector3 camera;
    public float cameraSpeed = 20f;
    Vector3 forward, right;

	// Use this for initialization
	private void Start ()
    {
        thisRigidbody = gameObject.GetComponent<Rigidbody>();
        thisRigidbody.maxAngularVelocity = terminalRotationSpeed;
        thisRigidbody.drag = drag;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveVector = PoolInput();
        Move();
		
        camera = new Vector3(mainCamera.transform.position.x + (joystick.Horizontal() * cameraSpeed * Time.deltaTime), mainCamera.transform.position.y + (joystick.Vertical() * cameraSpeed * Time.deltaTime), mainCamera.transform.position.z - (joystick.Horizontal() * cameraSpeed * Time.deltaTime));

        mainCamera.transform.position = camera;

    }

     void Move()
    {
        //thisRigidbody.AddForce((MoveVector * moveSpeed));
        Vector3 direction = PoolInput();
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * joystick.Horizontal();
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * joystick.Vertical();

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

     Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;
        //dir.x = Input.GetAxis("Horizontal");
        //dir.z = Input.GetAxis("Vertical");
        dir.x = joystick.Horizontal();
        dir.z = joystick.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();
        return dir;
    }
}
