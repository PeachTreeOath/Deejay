﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {
    
	// Use this for initialization
	void Start() {
		transform.SetParent(GameObject.Find("BobsledA").transform);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
