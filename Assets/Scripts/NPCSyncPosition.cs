using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NPCSyncPosition : NetworkBehaviour {

	[SyncVar]
	private Vector2 syncPos;
	public Transform mTransform;
	public float lerpRate = 15;

	void Update()
	{
		LerpPosition();
	}
	
	void FixedUpdate () {
		if (isServer) {
			TransmitPosition ();
		}
	}
	
	void LerpPosition()
	{
		if (!isServer) {
			mTransform.position = Vector2.Lerp(mTransform.position, syncPos, Time.deltaTime * lerpRate);
		}

	}
	
	[Command]
	void CmdProvidePositionToServer(Vector2 pos)
	{
		syncPos = pos;
	}
	
	[ClientCallback]
	void TransmitPosition()
	{
		CmdProvidePositionToServer (mTransform.position);
	}
}
