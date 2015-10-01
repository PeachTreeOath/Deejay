using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {
    
	// Use this for initialization
	void Start () {
        Debug.Log("H1");
        if (isLocalPlayer)
        {
            Debug.Log("H2");
            GetComponent<BobsledSC>().enabled = true;
            
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
