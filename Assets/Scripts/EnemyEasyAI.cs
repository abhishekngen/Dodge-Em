using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEasyAI : MonoBehaviour {
	private Vector2 disappear;
	public Rigidbody2D rb;
	public GameObject UIOp, TriCircle;
	public float rangex = 0.4f;
	public float rangey = 1f;
	public float maxvelocity = 2f;
	public Vector2 Movement;
	float acceltime = 0;
	float waittime = 3.5f; //used to be 2.4
	float movex = 0;
	float movey = 0;
	float movextest = 0;
	float moveytest = 0;
	bool conddir = false;
	private bool canmove = true;
	public float Timer = 5.0f;

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		waittime = Random.Range (1.7f, 2.5f);
		UIOp = GameObject.FindGameObjectWithTag ("UIOperator");
	}
	void Update(){
		UI score = UIOp.GetComponent<UI> ();
		acceltime -= Time.deltaTime;
		if (acceltime <= Time.deltaTime) {
			while (conddir == false) {
				
				movextest = Random.Range (-1f, 1f);
				moveytest = Random.Range (-1f, 1f);
				if (Mathf.Abs (movex - movextest) <= rangex) {
					conddir = false;
				} else if (Mathf.Abs (movey - moveytest) <= rangey) {
					conddir = false;
				} /*else if ((Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0)).y + transform.position.y) < 1 && moveytest <= 0) {
					conddir = false;
				}*/
				else {
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
			//score.scoreacc += 1;
			//Destroy (this.gameObject);
			CircleCollider2D box = GetComponent<CircleCollider2D> ();
			box.enabled = false;
			if (transform.position.y > Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height / 2, 0)).y) {
				disappear = new Vector2 (rb.velocity.x, 4f);
			} else {
				disappear = new Vector2 (rb.velocity.x, -4f);
			}
			canmove = false;
				
		}



	}
	void FixedUpdate(){
		
		if (canmove) {
			rb.AddForce (Movement);
		}
		if (canmove == false) {
			rb.velocity = disappear;
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
		//print (Movement);

		
		
	}
	void OnBecameInvisible(){
		
		Destroy (this.gameObject);
	}

}
