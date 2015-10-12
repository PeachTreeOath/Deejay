using UnityEngine;
using System.Collections;

public class NameHolderSC : MonoBehaviour {

	public string playerName;

	void Start()
	{
		DontDestroyOnLoad (this);
	}
}
