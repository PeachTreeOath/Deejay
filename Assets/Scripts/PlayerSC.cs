using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSC : NetworkBehaviour {

	[SyncVar]
	private float hInput;
	public float headMoveDist;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
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
		if (Input.GetKey (KeyCode.A)) {
			h -= 0.5f;
		}
		if (Input.GetKey (KeyCode.D)) {
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
