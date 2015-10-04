using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BobsledSC : NetworkBehaviour {

	public float speed;
	private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer) {
			float totalInput = 0;
			PlayerSC[] players = GetComponentsInChildren<PlayerSC> ();
			foreach (PlayerSC player in players) {
				totalInput += player.pollDirection () * 1 / players.Length;
			}
			rBody.velocity = new Vector2 (totalInput * speed, 0);
		}
	}
}
