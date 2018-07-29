using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBoss : MonoBehaviour {
	public Vector3 diff;
	public GameObject Player, Shooterbullet;
	private Vector3 targetpos;
	public float spawntimer = 4f;
	private float spawntime = 4f;
	public float life;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		spawntime -= Time.deltaTime;
		life -= Time.deltaTime;
		diff = Player.transform.position - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		if (spawntime <= 0) {
			Instantiate (Shooterbullet, transform.position, transform.rotation);
			spawntime = spawntimer;
		}
		if (life <= 0) {
			Destroy (this.gameObject);
		}
	}
}
