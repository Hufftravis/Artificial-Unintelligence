using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour 
{
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public bool IsDead = false;
	//private GameManager Gamecontroller;
	private GameObject TextHolder;
	void Start(){
		
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
			//Gamecontroller.GameOver();


		}
	}
}