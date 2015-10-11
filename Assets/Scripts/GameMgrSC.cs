using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameMgrSC : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		NetworkServer.SpawnObjects ();
		bool firstTeam = true;
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
			firstTeam = !firstTeam;
		}
	}
	
	// Update is called once per frame
	void Update () {

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
