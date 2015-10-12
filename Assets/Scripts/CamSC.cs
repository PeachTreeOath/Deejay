using UnityEngine;
using System.Collections;

public class CamSC : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (0, transform.position.y, transform.position.z);
	}
}
