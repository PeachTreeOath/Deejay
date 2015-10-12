using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class VictorySC : NetworkBehaviour {

	[SyncVar] public int victory = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (victory != 0) {
			if(victory == 1)
			{
				GameObject.Find ("VictoryTextA").GetComponent<Text>().enabled = true;
			}
			else
			{
				GameObject.Find ("VictoryTextB").GetComponent<Text>().enabled = true;
			}
		}
	}


}
