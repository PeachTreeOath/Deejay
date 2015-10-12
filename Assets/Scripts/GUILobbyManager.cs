using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GUILobbyManager : NetworkLobbyManager {

	public bool toggleHUD = false;
	// for users to apply settings from their lobby player object to their in-game player object
	public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer)
	{
		PlayerSC player = gamePlayer.GetComponent<PlayerSC> ();
		player.playerName = lobbyPlayer.GetComponent<LobbyPlayerSC> ().playerName;
		if (toggleHUD) {
			GetComponent<NetworkManagerHUDSC> ().showGUI = false;
		}

		return true;
	}

}
