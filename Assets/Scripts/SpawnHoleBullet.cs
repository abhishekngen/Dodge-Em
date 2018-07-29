using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHoleBullet : MonoBehaviour {

	public float spawntime = 3.0f;
	public bool spawned = false;
	public GameObject redball;
	// Use this for initialization
	void Start () {

	}
	void Update(){
		spawntime -= Time.deltaTime;
		if (spawntime <= 0 && spawned == false) {
			Instantiate (redball, transform.localPosition, Quaternion.Euler(0, 0, -87));
			spawned = true;
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (0, 0, 30 * Time.deltaTime);
		if (spawned == true) {
			transform.localScale -= new Vector3 (0, 0.1f, 0);
			if (transform.localScale.y <= 0) {
				Destroy (this.gameObject);
			}

		}
	}
}
