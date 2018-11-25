using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCycler : MonoBehaviour {
	public bool phase1 = true;
	public bool phase2 = false;
	public bool phase3 = false;
	public float timekeep = 2.0f;
	public GameObject Gun1;
	public GameObject Gun2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timekeep -= Time.deltaTime;

		if (timekeep < 0) {
			Switchmodes ();
			timekeep = 2.0f;
		}

	}
	public void Switchmodes(){
		if(phase1 = true){
			if (Gun1.tag == "disabled") {
				Gun1.SetActive (true);
				Gun1.tag = "enabled";
				Gun2.SetActive (false);
				Gun2.tag = "disabled";
			}
			else if (Gun1.tag == "enabled") {
				Gun2.SetActive (true);
				Gun2.tag = "enabled";
				Gun1.SetActive (false);
				Gun1.tag = "disabled";
			}
		}
	}
}
