using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour {
	public int damage = 60;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter2D(Collider2D x){
		Debug.Log ("arrrrrgh");
		Health playerhealth = x.gameObject.GetComponent<Health> ();
		if (playerhealth != null) {
			playerhealth.TakeDamage (damage/5);
		}
	}
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
