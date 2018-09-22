using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitiesPlayerMovementIncomplete : MonoBehaviour {

	public enum MoveType { VectorDirect, RotationDirect, Translate, Lerp, RigidBodyArrows, RigidBodyMouse}

    public MoveType moveType;

    public float speed = 10f;
    public float rotSpeed = 100f;
    public float lerpRotationSpeed = 2f;
    public float stoppingDistance = 1f;

    public LayerMask layerMask;
    public Vector3 goal;
    public Quaternion rot;
    

    Rigidbody rb;
    
	void Start () {
        goal = transform.position;
        rot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        
	}
	
	void Update () {
        Vector3 position = transform.position;
		switch (moveType)
        {
            case MoveType.VectorDirect:
                position.x += speed * Input.GetAxis("Horizontal") * Time.deltaTime;
                position.z += speed * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position = position;
                break;
            case MoveType.RotationDirect:
                float forwardSpeed = speed * Input.GetAxis("Vertical") * Time.deltaTime;
                float rotation = rotSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
                Quaternion rotDirect = Quaternion.Euler(0f, rotation, 0f);
                transform.rotation *= rotDirect;
                transform.position += forwardSpeed * transform.forward;
                break;
            case MoveType.Translate:
            //TODO: implement get mouse position below to get the rot variable from user input of a click that is used in Quaternion.Lerp
                getMousePosition();
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotSpeed);
                Vector3 direction = goal - transform.position;
                if(direction.magnitude > stoppingDistance)
                {
                    transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
                }
                break;
            case MoveType.Lerp:
                getMousePosition();
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotSpeed);
                if(Vector3.Distance(transform.position, goal) > stoppingDistance)
                {
                    transform.position = Vector3.Lerp(transform.position, goal, Time.deltaTime);
                }
                break;
        }
    }
    private void FixedUpdate()
    {
        switch (moveType)
        {
            case MoveType.RigidBodyArrows:
                goal = transform.forward;
                float translation = Input.GetAxis("Vertical") * speed;
                float rotation = Input.GetAxis("Horizontal") * rotSpeed;
                translation *= Time.deltaTime;
                rotation *= Time.deltaTime;
                Quaternion turn = Quaternion.Euler(0f, rotation, 0f);
                rb.MovePosition(rb.position + transform.forward * translation);
                rb.MoveRotation(turn * rb.rotation);
                break;
            case MoveType.RigidBodyMouse:
                getMousePosition();
                Quaternion lerpRot = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * lerpRotationSpeed);
                //TODO: using stopping distance and Vector3.Distance, use MoveRotation and MovePosition and lerpRot and goal variables to move the rigid body towards the mouse position
                rb.MoveRotation(lerpRot);
                if(Vector3.Distance(transform.position, goal) > stoppingDistance)
                {
                    Vector3 lerpTarget = Vector3.Lerp(transform.position, goal, Time.deltaTime * speed);
                    rb.MovePosition(lerpTarget + transform.forward * speed * Time.deltaTime);
                }
                break;
        }
    }
    public void getMousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000, layerMask, QueryTriggerInteraction.Ignore))
            {
                goal = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                rot = Quaternion.LookRotation(goal - transform.position)
            }
        }
    }
}
