using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalSetup : NetworkBehaviour {
	public SpecialManager test;
	// Use this for initialization

	public GameObject NotUs;
	// Use this for initialization
	void Start () {
		test = GameObject.FindObjectOfType<SpecialManager> ();
		test.playernum += 1;
		if (isLocalPlayer){
			return;
		}

		NotUs.GetComponent<MovementScript> ().enabled= false;
		NotUs.GetComponent<Gun> ().enabled= false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
