using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
	public const int maxBossHealth = 1000;
	public int currentBossHealth = maxBossHealth;
	public bool IsDead = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void TakeDamage(int amount)
	{
		currentBossHealth -= amount;
		if (currentBossHealth <= 0)
		{
			currentBossHealth = 0;
			Debug.Log("Dead Boss!");
			IsDead = true;
			Destroy (gameObject);



		}
		else if(currentBossHealth <= (maxBossHealth*.75)){
			
			//change boss attack pattern.
				Debug.Log("Increasing Intensity");
		}
		else if(currentBossHealth <= (maxBossHealth/2)){

			//change boss attack pattern.
			Debug.Log("Increasing Intensity.... Again");
		}
		else if(currentBossHealth <= (maxBossHealth/4)){

			//change boss attack pattern.
			Debug.Log("Sorry Boss, this don't look too good.");
		}
	}
}
