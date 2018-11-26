using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour 
{
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public bool IsDead = false;
	public SpecialManager test;
	//private GameManager Gamecontroller;

	void Start(){
		test = GameObject.FindObjectOfType<SpecialManager> ();
			
		//GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		//Gamecontroller = gameControllerObject.GetComponent<GameManager> ();

}
	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
			IsDead = true;
			test.playernum = test.playernum - 1;
			//Gamecontroller.GameOver();
			Destroy(gameObject);

			this.enabled = false;


		}
	}
}