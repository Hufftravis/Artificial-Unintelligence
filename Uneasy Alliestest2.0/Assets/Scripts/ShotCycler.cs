using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCycler : MonoBehaviour {
	public bool phase1;
	public bool phase2 ;
	public bool phase3 ;
	public int phase;
	public float timekeep = 2.0f;
	public GameObject Gun1;
	public GameObject Gun2;
	public GameObject Gun3;
	public GameObject Gun4;
	public GameObject Gun5;
	public GameObject Gun6;

	// Use this for initialization
	void Start () {
		phase = 1;
		 phase1 = true;
		 phase2 = false;
		 phase3 = false;
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
		switch (phase) {
		case 1:
			if (Gun1.tag == "disabled") {
				Gun1.SetActive (true);
				Gun1.tag = "enabled";
				Gun2.SetActive (false);
				Gun2.tag = "disabled";
			} else if (Gun1.tag == "enabled") {
				Gun2.SetActive (true);
				Gun2.tag = "enabled";
				Gun1.SetActive (false);
				Gun1.tag = "disabled";
			}
			break;
		case 2:
			Gun1.SetActive (false);
			Gun2.SetActive (false);


			if (Gun3.tag == "disabled") {
				Gun3.SetActive (true);
				Gun3.tag = "enabled";
				Gun4.SetActive (false);
				Gun4.tag = "disabled";
			} else if (Gun3.tag == "enabled") {
				Gun4.SetActive (true);
				Gun4.tag = "enabled";
				Gun4.SetActive (false);
				Gun4.tag = "disabled";
			}
			break;
			
		}
		/*if (phase1) {
			if (Gun1.tag == "disabled") {
				Gun1.SetActive (true);
				Gun1.tag = "enabled";
				Gun2.SetActive (false);
				Gun2.tag = "disabled";
			} else if (Gun1.tag == "enabled") {
				Gun2.SetActive (true);
				Gun2.tag = "enabled";
				Gun1.SetActive (false);
				Gun1.tag = "disabled";
			}
		} 
		else if (phase2) {
			
			Gun1.SetActive (false);
			Gun2.SetActive (false);


			if (Gun3.tag == "disabled") {
				Gun3.SetActive (true);
				Gun3.tag = "enabled";
				Gun4.SetActive (false);
				Gun4.tag = "disabled";
			} else if (Gun3.tag == "enabled") {
				Gun4.SetActive (true);
				Gun4.tag = "enabled";
				Gun4.SetActive (false);
				Gun4.tag = "disabled";
			}*/
		}
}
