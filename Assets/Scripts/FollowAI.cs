using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour {
	public float timearrive = 3f;
	public Rigidbody2D rb;
	public GameObject player;
	//public float maxvelocity = 2f;
	public Vector2 Movement;
	public float Timer = 5.0f;
	private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		if (GameObject.Find ("FollowEnemy")) {
			GameObject follow = GameObject.Find ("FollowEnemy");
			Destroy (follow.gameObject);
		}
	}
	void Update(){
		
		Timer -= Time.deltaTime;
		if (Timer <= 0) {
			
			Destroy (this.gameObject);
		}
		transform.position = Vector3.SmoothDamp (transform.position, player.transform.position, ref velocity, timearrive); 



	}
	/*void FixedUpdate(){



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
		print (Movement);



	}*/
}
