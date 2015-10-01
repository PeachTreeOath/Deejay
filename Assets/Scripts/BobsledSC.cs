using UnityEngine;
using System.Collections;

public class BobsledSC : MonoBehaviour {

	public float speed;
	private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		rBody.velocity = new Vector2 (speed * h, speed * v);
	}
}
