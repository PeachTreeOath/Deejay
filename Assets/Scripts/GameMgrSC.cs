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
					GameObject.Find("VictoryManager").GetComponent<VictorySC>().victory = 1;
				}
				else if(bobsled.name == "BobsledB")
				{
					GameObject.Find("VictoryManager").GetComponent<VictorySC>().victory = 2;
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

		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Player");
		shuffle (objs);
		
		foreach(GameObject obj in objs)
		{
			PlayerSC player = obj.GetComponent<PlayerSC>();
			if(firstTeam)
			{
				player.team = 1;
			}
			else{
				player.team = 2;
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
