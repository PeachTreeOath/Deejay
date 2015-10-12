using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GUILobbyManager : NetworkLobbyManager {
	/*
	// for users to apply settings from their lobby player object to their in-game player object
	public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer)
	{
		string name = GameObject.Find ("NameHolder").GetComponent<NameHolderSC> ().playerName;
		PlayerSC player = gamePlayer.GetComponent<PlayerSC> ();
		player.playerName = name;

		NetworkManagerHUDSC scr = GetComponent<NetworkManagerHUDSC> ();

		return true;
	}*/

}
