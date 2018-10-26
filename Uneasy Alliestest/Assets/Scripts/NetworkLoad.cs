using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkLoad : NetworkBehaviour {

	// Use this for initialization
	public void LoadNetwork(){
		
		NetworkManager.singleton.StartHost();
	}
}
