using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {
	public GameObject Scoretext;
	// Use this for initialization
	public Rigidbody2D rb;
	public float rangex = 0.4f;
	public float rangey = 1f;
	public float maxvelocity = 2f;
	public Vector2 Movement;
	float acceltime = 0;
	float waittime = 2.2f;
	float movex = 0;
	float movey = 0;
	float movextest = 0;
	float moveytest = 0;
	bool conddir = false;
	public float Timer = 5.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		waittime = Random.Range (1.7f, 2.3f);
		Scoretext = GameObject.FindGameObjectWithTag ("UIOperator");
	 

	}
	void Update(){
		
		acceltime -= Time.deltaTime;
		if (acceltime <= Time.deltaTime) {
			while (conddir == false) {

				movextest = Random.Range (-1f, 1f);
				moveytest = Random.Range (-1f, 1f);
				if (Mathf.Abs (movex - movextest) <= rangex) {
					conddir = false;
				} else if (Mathf.Abs (movey - moveytest)<= rangey) {
					conddir = false;
				} else {
					conddir = true;
					movex = movextest;
					movey = moveytest;
				}
			}
			Movement = new Vector2 (movex * maxvelocity, movey * maxvelocity);
			conddir = false;
			acceltime = waittime;
		}
		Timer -= Time.deltaTime;
		if (Timer <= 0) {
			Destroy (this.gameObject);
		}



	}
	void FixedUpdate(){


		rb.AddForce (Movement);
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



	}
	void OnCollisionEnter2D(Collision2D other){
		UIMat score = Scoretext.GetComponent<UIMat> ();
		if (other.gameObject.tag == "Player") {
			score.score1 += 5;
			score.PlusFive ();
			Destroy (this.gameObject);
		}
	}
			
}
