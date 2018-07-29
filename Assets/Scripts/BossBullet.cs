using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour {
	private Quaternion right = Quaternion.Euler(0, 0, -87);
	private Quaternion left = Quaternion.Euler(0, 0, 87);
	public float speed;
	public int leftorright = 0;
	private bool collcheck = true;
	// Use this for initialization
	void Start () {
		//transform.localRotation = Quaternion.Euler(0, 0, -80);

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localRotation == right) {
			//transform.Translate (transform.up * speed * Time.deltaTime);
			transform.Translate(0, speed*Time.deltaTime, 0);
		} else {
			transform.Translate (0, speed*Time.deltaTime, 0);
		}
	}
	void FixedUpdate(){
		
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "topcoll") {
			collcheck = false;
			GetComponent<PolygonCollider2D> ().enabled = false;
		}
		if (collcheck) {
			if (leftorright == 0) {
				Switchrot (leftorright);
				leftorright = 1;
			} else {
				Switchrot (leftorright);
				leftorright = 0;
			}
		}

	}
	void Switchrot(int dir){
		if(dir==0){
			transform.localRotation = left;
		}
		else{
			transform.localRotation = right;
		}
	}
	void OnBecameInvisible(){
		Destroy(this.gameObject);
	}
}
