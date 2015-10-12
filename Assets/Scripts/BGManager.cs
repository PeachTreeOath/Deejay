using UnityEngine;
using System.Collections;

public class BGManager : MonoBehaviour {

	public int numBG;
	public GameObject bg;

	// Use this for initialization
	void Start () {
		generateBG ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void generateBG()
	{
		GameObject parent = GameObject.Find ("Backgrounds");
		float newX = 0;
		float newY = -7.5f;
		for (int i = 0; i < numBG; i++) {
			Vector3 pos = new Vector3(newX, newY, 0);
			GameObject obj = (GameObject)GameObject.Instantiate(bg, pos, Quaternion.identity);
			obj.transform.parent = parent.transform;
			newY += 7.5f;
		}
	}
}
