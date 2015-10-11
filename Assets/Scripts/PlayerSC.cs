using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSC : NetworkBehaviour {

	[SyncVar]
	private float hInput;
	[SyncVar]
	public int team = 0;
	public float headMoveDist;
	public string playerName;
	private bool teamSet = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (teamSet == false && team != 0) {
			string teamName;
			if(team == 1)
			{
				teamName = "BobsledA";
			}
			else
			{
				teamName = "BobsledB";
			}
			transform.parent = GameObject.Find(teamName).transform;
			teamSet = true;
		}

		if (isLocalPlayer) {
			float h = getHorizontalInput ();
			transform.localPosition = new Vector2 (headMoveDist * h, transform.localPosition.y);
			CmdTransmitInput (h);
		} else {
			transform.localPosition = new Vector2 (headMoveDist * hInput, transform.localPosition.y);
		}
	}

	public float pollDirection()
	{
		return hInput;
	}

	private float getHorizontalInput()
	{
		float h = 0;
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			h -= 0.5f;
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)){
			h += 0.5f;
		}

		return h;
	}

	[Command]
	private void CmdTransmitInput(float h)
	{
		hInput = h;
	}
}
