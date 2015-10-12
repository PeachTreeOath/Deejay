using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GUITextSC : NetworkBehaviour {

	[SyncVar] public int victory = 0;
	[SyncVar] public string name1;
	[SyncVar] public string name2;
	[SyncVar] public string name3;
	[SyncVar] public string name4;
	[SyncVar] public string name5;
	[SyncVar] public string name6;
	[SyncVar] public string name7;
	[SyncVar] public string name8;

	private Text text1;
	private Text text2;
	private Text text3;
	private Text text4;
	private Text text5;
	private Text text6;
	private Text text7;
	private Text text8;

	// Use this for initialization
	void Start () {
		text1 = GameObject.Find ("NameA1").GetComponent<Text> ();
		text2 = GameObject.Find ("NameA2").GetComponent<Text> ();
		text3 = GameObject.Find ("NameA3").GetComponent<Text> ();
		text4 = GameObject.Find ("NameA4").GetComponent<Text> ();
		text5 = GameObject.Find ("NameB1").GetComponent<Text> ();
		text6 = GameObject.Find ("NameB2").GetComponent<Text> ();
		text7 = GameObject.Find ("NameB3").GetComponent<Text> ();
		text8 = GameObject.Find ("NameB4").GetComponent<Text> ();

		GameObject.Find("NetworkManager").GetComponent<NetworkManagerHUDSC> ().showGUI = false;
	}
	
	// Update is called once per frame
	void Update () {
		text1.text = name1;
		text2.text = name2;
		text3.text = name3;
		text4.text = name4;
		text5.text = name5;
		text6.text = name6;
		text7.text = name7;
		text8.text = name8;

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
