using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameMgrSC : NetworkBehaviour {

	public float finishLine;
	private float initTime;
	private bool victory = false;

	// Use this for initialization
	void Start () {
		Invoke ("SetTeams", 1f);
		Invoke ("StartSleds", 2f);

		GameObject.Find("NetworkManager").GetComponent<NetworkManagerHUDSC> ().showGUI = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!victory) {
			checkVictory ();
		}
	}

	private void checkVictory()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Bobsled");
		foreach(GameObject obj in objs)
		{
			Transform bobsled = obj.GetComponent<Transform>();
			if(bobsled.position.y > finishLine)
			{
				if(bobsled.name == "BobsledA")
				{
					GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().victory = 1;
				}
				else if(bobsled.name == "BobsledB")
				{
					GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().victory = 2;
				}
				victory = true;
			}
		}
	}

	private void StartSleds()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Bobsled");
		foreach(GameObject obj in objs)
		{
			obj.GetComponent<BobsledSC>().startSled();
		}
	}

	private void SetTeams()
	{
		bool firstTeam = true;
		int position = 1;
		int teamApos = 1;
		int teamBpos = 1;

		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Player");
		shuffle (objs);
		
		foreach(GameObject obj in objs)
		{
			PlayerSC player = obj.GetComponent<PlayerSC>();
			if(firstTeam)
			{
				player.team = 1;
				/*
				switch(teamApos)
				{
					case 1:
						GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().name1 = player.playerName;
						break;
					case 2:
						GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().name2 = player.playerName;
						break;
					case 3:
						GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().name3 = player.playerName;
						break;
					case 4:
						GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().name4 = player.playerName;
						break;

				}
				teamApos++;
				*/
			}
			else
			{
				player.team = 2;
				/*
				switch(teamBpos)
				{
				case 1:
					GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().name5 = player.playerName;
					break;
				case 2:
					GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().name6 = player.playerName;
					break;
				case 3:
					GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().name7 = player.playerName;
					break;
				case 4:
					GameObject.Find("GuiTextManager").GetComponent<GUITextSC>().name8 = player.playerName;
					break;
					
				}
				teamBpos++;
				*/
			}
			player.pos = position;

			firstTeam = !firstTeam;
			if(firstTeam)
			{
				position++;
			}
		}
	}

	private void shuffle(GameObject[] objs)
	{
		for (int i = 0; i < objs.Length; i++ )
		{
			GameObject tmp = objs[i];
			int r = Random.Range(i, objs.Length);
			objs[i] = objs[r];
			objs[r] = tmp;
		}
	}

}
