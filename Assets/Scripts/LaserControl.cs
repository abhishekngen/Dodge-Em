using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour {
	float rechargetimer = 0f;
	float rechargetime = 0f;
	public float upperrechargelimit = 30f;
	public float lowerrechargelimit = 15f;
	public GameObject laser;
	// Use this for initialization
	void Start () {
		rechargetime = Random.Range (lowerrechargelimit, upperrechargelimit);
		rechargetimer = rechargetime;
	}

	// Update is called once per frame
	void Update () {
		rechargetimer -= Time.deltaTime;
		if (rechargetimer <= 0) {
			float ypos = Random.Range (0f, Screen.height);
			float xpos = Screen.width;
			Vector3 laserspawnpos1 = Camera.main.ScreenToWorldPoint(new Vector3 (xpos, ypos, 0));
			Vector3 laserspawnpos = new Vector3 (laserspawnpos1.x, laserspawnpos1.y, 0);
			Instantiate (laser, laserspawnpos, Quaternion.identity);
			rechargetime = Random.Range (lowerrechargelimit, upperrechargelimit);
			rechargetimer = rechargetime;
		}

		
	}
}
