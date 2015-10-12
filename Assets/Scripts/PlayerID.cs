using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerID : NetworkBehaviour {

	[SyncVar] public string playerUniqueIdentity;
	private NetworkInstanceId playerNetID;
	private Transform mTransform;

	public override void OnStartLocalPlayer()
	{
		GetNetIdentity ();
		SetIdentity ();
	}

	// Use this for initialization
	void Awake () {
		mTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (mTransform.name == "" || mTransform.name == "playerPF(Clone)") {
			SetIdentity();
		}
	}

	[Client]
	void GetNetIdentity()
	{
		playerNetID = GetComponent<NetworkIdentity> ().netId;
		CmdTellServerMyIdentity (MakeUniqueIdentity ());
	}

	void SetIdentity()
	{
		if (!isLocalPlayer) {
			mTransform.name = playerUniqueIdentity;
		} else {
			mTransform.name = MakeUniqueIdentity();
		}
	}

	string MakeUniqueIdentity()
	{
		string uniqueName = "Player" + playerNetID.ToString ();
		return uniqueName;
	}

	[Command]
	void CmdTellServerMyIdentity(string name)
	{
		playerUniqueIdentity = name;
	}
}
