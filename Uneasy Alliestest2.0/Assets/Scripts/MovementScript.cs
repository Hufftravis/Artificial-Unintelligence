using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class MovementScript : MonoBehaviour {
	public Rigidbody2D rigidbody2D;
	// Use this for initialization
	void Start () {
        //rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        var speed = 5;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        rigidbody2D.angularVelocity = 0;
        /*float input = Input.GetAxis("Vertical");
        rigidbody2D.AddForce(gameObject.transform.up * speed * input);*/
		rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, Input.GetAxis ("Vertical") * speed);
    }
}
