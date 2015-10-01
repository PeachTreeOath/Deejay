using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncPosition : NetworkBehaviour {

    [SyncVar]
    private Vector2 syncPos;
    public Transform mTransform;
    public float lerpRate = 15;
    
	
	void FixedUpdate () {
		TransmitPosition ();
		LerpPosition();
	}

    void LerpPosition()
    {
        if (!isLocalPlayer)
        {
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
		if (isLocalPlayer) {
			CmdProvidePositionToServer (mTransform.position);
		}
	}
}
