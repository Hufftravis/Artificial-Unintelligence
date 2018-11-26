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
	void OnTriggerEnter2D(Collider2D collision){
		BossHealth boss = collision.gameObject.GetComponent<BossHealth> ();
		if (boss != null) {
			Debug.Log ("ouch");
			boss.TakeDamage (damage);
		}
		}


	void OnTriggerEnter()
    {
		//reinstate when player health is established.
		/*if (GetComponent<Collider>().gameObject.GetComponent<Player>() != null 
			&& GetComponent<Collider>().gameObject.tag == "Player") {
			GetComponent<Collider>().gameObject.GetComponent<Player>().TakeDamage(damage);
		}*/
		/*if (GetComponent<Collider>().gameObject.GetComponent<BossHealth>() != null 
			&& GetComponent<Collider>().gameObject.tag == "Boss") {
			GetComponent<Collider>().gameObject.GetComponent<BossHealth>().TakeDamage(damage);
		}*/
		Destroy (gameObject);

    }
}
