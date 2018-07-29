using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardyh : MonoBehaviour {
	Rigidbody2D rb;
	public float maxvelocity = 6f;
	private float life;
	Vector2 forwardvelocity;
	private Vector2 disappear;
	private bool canmove = true;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		life = Random.Range (5f, 7f);
	}
	
	// Update is called once per frame
	void Update () {
		life -= Time.deltaTime;
		if (life <= 0) {
			CircleCollider2D box = GetComponent<CircleCollider2D> ();
			box.enabled = false;
			if (transform.position.y > Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height / 2, 0)).y) {
				disappear = new Vector2 (rb.velocity.x, 4f);
			} else {
				disappear = new Vector2 (rb.velocity.x, -4f);
			}
			canmove = false;
		}
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
	void FixedUpdate(){
		if (canmove) {
			if (rb.velocity.x > 0 || rb.velocity.y > 0) {
				if (rb.velocity != forwardvelocity) {
					forwardvelocity = rb.velocity;

					rb.AddForce (forwardvelocity);
				}
			}
		} else {
			rb.velocity = disappear;
		}


	}
}
