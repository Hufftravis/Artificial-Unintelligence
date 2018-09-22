using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public enum MoveType { VectorDirect, RotationDirect, Translate, Lerp, RigidBodyArrows, RigiBodyMouse}
    public MoveType moveType;

    public float speed = 10f;
    public float rotSpeed = 5f;
    public float stoppingDistance = 1f;

    public LayerMask layerMask;
    public Vector3 goal;
    public Quaternion rot;
    

	void Start () {
        goal = transform.position;
        rot = transform.rotation;
		
	}
	
	
	void Update () {
        Vector3 position = transform.position;
        switch (moveType)
        {
            case MoveType. VectorDirect:
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
                getMousePosition();
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotSpeed);
                Vector3 direction = goal - transform.position;
                if(direction.magnitude > stoppingDistance)
                {
                    transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
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
            if(Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
            {
                goal = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                rot = Quaternion.LookRotation(goal - transform.position);
            }
        }
    }
}
