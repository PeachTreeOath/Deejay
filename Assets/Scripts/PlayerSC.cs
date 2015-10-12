using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSC : NetworkBehaviour {

	[SyncVar]
	private float hInput;
	[SyncVar]
	public int team = 0;
	[SyncVar]
	public int pos = 0;
	public float headMoveDist;
	public string playerName;
	private bool teamSet = false;

	public Sprite sprTeamA;
	public Sprite sprTeamB;
	public Sprite sprSelf;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (teamSet == false && team != 0 && pos != 0) {
			string teamName;
			if(team == 1)
			{
				teamName = "BobsledA";
				GetComponent<SpriteRenderer>().sprite = sprTeamA;
			}
			else
			{
				teamName = "BobsledB";
				GetComponent<SpriteRenderer>().sprite = sprTeamB;
			}
			transform.parent = GameObject.Find(teamName).transform;
			transform.position = GameObject.Find("SpawnPoint" + pos).GetComponent<Transform>().position;
			teamSet = true;

			if (isLocalPlayer) {
				GetComponent<SpriteRenderer>().sprite = sprSelf;
			}
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
