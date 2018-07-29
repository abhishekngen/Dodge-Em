using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {
	public GameObject Triangle, BulletRight, BulletLeft, FollowBoss, Shooter;
	private float spawntimer;
	private float spawntime = 0f;
	private int choose;
	// Use this for initialization
	void Start () {
		spawntimer = Random.Range (30f, 40f);
		spawntime = spawntimer;

	}
	
	// Update is called once per frame
	void Update () {
		spawntime -= Time.deltaTime;
		if (spawntime <= 0) {
			choose = Random.Range (1, 5);
			if (choose == 0) {
			} else if (choose == 1) {
				Tri ();
			} else if (choose == 2) {
				Bullet ();
			} else if (choose == 3) {
				Followboss ();
			} else if (choose == 4) {
				Shoot ();
			}
			spawntime = spawntimer;
		}
		
		
	}
	void Tri(){
		Vector2 spawnpos = Camera.main.ScreenToWorldPoint (new Vector2 (Random.Range (0f, Screen.width), Random.Range (0f, Screen.height)));
		Instantiate (Triangle, spawnpos, Quaternion.identity);
	}
	void Bullet(){
		Vector2 spawnpos = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width / 15, Screen.height / 15));
		Instantiate (BulletRight, spawnpos, Quaternion.identity);
		int choose1 = Random.Range (0, 2);
		if (choose1 == 0) {
			spawnpos = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width - (Screen.width / 15), Screen.height/15));
			Instantiate (BulletLeft, spawnpos, Quaternion.identity);
		}
	}
	void Followboss(){
		Vector2 spawnpos = Camera.main.ScreenToWorldPoint (new Vector2 (Random.Range (0f, Screen.width), Random.Range (0f, Screen.height)));
		Instantiate (FollowBoss, spawnpos, Quaternion.identity);
	}
	void Shoot(){
		Vector2 spawnpos = Camera.main.ScreenToWorldPoint (new Vector2 (Random.Range (0f, Screen.width), Random.Range (0f, Screen.height)));
		Instantiate (Shooter, spawnpos, Quaternion.identity);
	}
		
}
