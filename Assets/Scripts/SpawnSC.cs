﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpawnSC : NetworkBehaviour {

	public GameObject bobsledPF;

	public GameObject pf1;
	public GameObject pf2;
	public GameObject pf3;
	public GameObject pf4;
	public GameObject pf5;
	public GameObject pf6;
	public GameObject pf7;

	public int numBG;
	public int numSections;

	// Use this for initialization
	void Start () {
		float startY = 5;
		float finishY = ((numBG - 1) * 7.5f) - 5f;
		GameObject.Find ("GameManager").GetComponent<GameMgrSC> ().finishLine = finishY;
		float sectionSize = (finishY - startY) / numSections;

		for (int section = 0; section < numSections; section++) {
			for (int i = 0; i < 5 + section * 6; i++) {
				float x = Random.Range(-5,5);
				float y = Random.Range(startY + sectionSize * section, startY + sectionSize * (section+1));
				Vector3 pos = new Vector3(x,y,0);
				generateObject (pos);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void generateObject(Vector3 pos)
	{
		GameObject pf = null;
		int num = (int)Random.Range (0, 7);
		switch (num) {
		case 0: 
			pf = pf1;
			break;
		case 1: 
			pf = pf2;
			break;
		case 2: 
			pf = pf3;
			break;
		case 3: 
			pf = pf4;
			break;
		case 4: 
			pf = pf5;
			break;
		case 5: 
			pf = pf6;
			break;
		case 6: 
			pf = pf7;
			break;
		}

		GameObject obj = (GameObject)GameObject.Instantiate(pf, pos, Quaternion.identity);
		NetworkServer.Spawn (obj);
	}

}
