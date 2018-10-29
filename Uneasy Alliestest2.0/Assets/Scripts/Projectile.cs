using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public int damage =10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 2);
	}
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
	void OnTriggerEnter2D(){
		if (GetComponent<CircleCollider2D>().gameObject.GetComponent<BossHealth>() != null 
			&& GetComponent<CircleCollider2D>().gameObject.tag == "Boss") {
			GetComponent<CircleCollider2D>().gameObject.GetComponent<BossHealth>().TakeDamage(damage);
			Destroy (gameObject);
		}

	}
    void OnCollisionEnter()
    {
		//reinstate when player health is established.
		/*if (GetComponent<Collider>().gameObject.GetComponent<Player>() != null 
			&& GetComponent<Collider>().gameObject.tag == "Player") {
			GetComponent<Collider>().gameObject.GetComponent<Player>().TakeDamage(damage);
		}*/
		if (GetComponent<Collider>().gameObject.GetComponent<BossHealth>() != null 
			&& GetComponent<Collider>().gameObject.tag == "Boss") {
			GetComponent<Collider>().gameObject.GetComponent<BossHealth>().TakeDamage(damage);
		}
		Destroy (gameObject);

    }
}
