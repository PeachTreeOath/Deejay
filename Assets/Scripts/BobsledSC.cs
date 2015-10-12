using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BobsledSC : NetworkBehaviour {

	public float speed;
	public float accel;
	public float collidePenalty;
	public float xBoundL = -4.5f;
	public float xBoundR = 4.5f;
	private Rigidbody2D rBody;
	private bool started = false;
	[SyncVar]
	private bool collidable = true;
	private string[] layers = {"Hidden", "Bobsleds"};
	private float lastCollideTime = 0;
	private float lastFlashTime = 0;
	private int layerIndex = 0;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D> ();
	}

	public void startSled()
	{
		started = true;
	}

	// Update is called once per frame
	void Update () {
		if (isServer && started) {
			if (!collidable && Time.time > lastCollideTime + 1) {
				collidable = true;
			}

			float totalInput = 0;
			PlayerSC[] players = GetComponentsInChildren<PlayerSC> ();
			foreach (PlayerSC player in players) {
				totalInput += player.pollDirection () * 1 / players.Length;
			}
			rBody.velocity = new Vector2 (totalInput * speed, rBody.velocity.y);
			rBody.AddForce(new Vector2(0, accel));

			if (transform.position.x < xBoundL) {
				transform.position = new Vector3(xBoundL, transform.position.y);
			}
			else if (transform.position.x > xBoundR) {
				transform.position = new Vector3(xBoundR, transform.position.y);
			}
		}

		if (isClient) {
			if(!collidable)
			{
				Flash();
			}
			else
			{
				GetComponent<SpriteRenderer>().sortingLayerName = "Bobsleds";
			}

		}

	}

	public void collide()
	{
		if (isServer) {
			if (collidable) {
				rBody.velocity = new Vector2 (rBody.velocity.x, rBody.velocity.y * collidePenalty);
				collidable = false;
			}
		}

		lastCollideTime = Time.time;
	}

	void Flash()
	{
		if (Time.time > lastFlashTime + 0.05f) {
			GetComponent<SpriteRenderer>().sortingLayerName = layers[layerIndex % 2];
			layerIndex++;
			lastFlashTime = Time.time;
		}
	}
}
