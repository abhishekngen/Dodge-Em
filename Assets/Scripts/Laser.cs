using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	public float growspeed = 0.75f;
	float scale = 0;
	public float speed = 1f;
	public float duration = 1.5f;
	BoxCollider2D collider;
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if (duration > 0) {
			scale += growspeed * Time.deltaTime;
			transform.localScale = new Vector3 (scale, transform.localScale.y, 1);
		}
		if (duration <= 0) {
			speed = 10f;
		}
		transform.position = new Vector3 (transform.position.x - speed*Time.deltaTime, transform.position.y, 0);

		
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
		}
	}

}
