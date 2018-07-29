using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBullet : MonoBehaviour {
	Rigidbody2D rb;
	public float maxvelocity;
	public GameObject Shooter;
	private Vector3 aim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		ShooterBoss shoot = Shooter.GetComponent<ShooterBoss> ();
		aim = shoot.diff;
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
	void FixedUpdate(){
		transform.Translate (0, maxvelocity* Time.deltaTime, 0);
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "topcoll" || other.gameObject.tag == "screencoll") {
			GetComponent<CircleCollider2D> ().enabled = false;
		}
	}

}
