using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndofGame : MonoBehaviour {
	public BossHealth TheBoss;
	public Text endText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (TheBoss.IsDead) {
			Gameover ();
		}
	}
	public void Gameover(){
		Time.timeScale = 0;
		endText.text = "Congratulations the boss is dead";
	}

}
