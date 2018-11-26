using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialManager : MonoBehaviour {
	public int playernum=1;
	public Text endtext;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playernum <= 0) {
			Time.timeScale = 0;
			endtext.text = "fail";
		}
	}
}
