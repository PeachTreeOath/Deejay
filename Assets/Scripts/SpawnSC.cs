using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpawnSC : NetworkBehaviour {

	public GameObject bobsledPF;

	// Use this for initialization
	void Start () {
		//GameObject bobsled = (GameObject)GameObject.Instantiate (bobsledPF, new Vector3 (0, 0, 0), Quaternion.identity);
		//bobsled.name = "Bobsled";
		//NetworkServer.Spawn (bobsled);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
