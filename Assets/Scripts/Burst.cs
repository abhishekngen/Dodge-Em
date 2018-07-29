using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour {
	public float xdir = 0;
	public float ydir = 0;
	public float speed = 5f;
	public float maxvelocity = 5f;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		burstdir (xdir, ydir);
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.y > maxvelocity) {
			rb.velocity = new Vector2 (rb.velocity.x, maxvelocity);

		}
		if (rb.velocity.y < -maxvelocity) {
			rb.velocity = new Vector2 (rb.velocity.x, -maxvelocity);
		}
		if (rb.velocity.x > maxvelocity) {
			rb.velocity = new Vector2 (maxvelocity, rb.velocity.y);
		}
		if (rb.velocity.x < -maxvelocity) {
			rb.velocity = new Vector2 (-maxvelocity, rb.velocity.y);
		}

		
	}
	public void burstdir(float xdir1, float ydir1){
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (xdir * speed, ydir * speed));
		
	}
		
}
