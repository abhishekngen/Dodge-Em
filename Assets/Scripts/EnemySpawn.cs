using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	public GameObject EnemyEasy;
	public GameObject EnemyMedium;
	public GameObject EnemyInsane;
	public GameObject Money;
	public GameObject EnemyFollow;
	float spawntimer = 0f;
	float choose;
	public float spawntime = 2f;
	public float mediumspawntime = 15.0f;
	public float insanespawntime = 120.0f;
	// Use this for initialization
	void Start () {
		Camera c = Camera.main;

	}
	void Update(){
		insanespawntime -= Time.deltaTime;
		mediumspawntime -= Time.deltaTime;
		float ypos = Random.Range (0f, Screen.height);
		float xpos = Random.Range (0f, Screen.width);
		Vector3 spawnpos1 = Camera.main.ScreenToWorldPoint(new Vector3 (xpos, ypos, 0));
		Vector3 spawnpos = new Vector3(spawnpos1.x, spawnpos1.y, 0);
		spawntimer -= Time.deltaTime;
		if (spawntimer <= Time.deltaTime) {
			if (insanespawntime <= 0) {
				choose = Random.Range (1f, 2f);
				if (choose <= 1.4) {
					Instantiate (EnemyInsane, spawnpos, Quaternion.identity);
				} else if (choose > 1.4 && choose <= 1.6) {
					Instantiate (EnemyMedium, spawnpos, Quaternion.identity);
				} else if (choose > 1.6 && choose <= 1.8 && GameObject.Find("FollowEnemy(Clone)") == false) {
					Instantiate (EnemyFollow, spawnpos, Quaternion.identity);
				} else {
					Instantiate (Money, spawnpos, Quaternion.identity);
				}
			}
			if (mediumspawntime <= 0 && insanespawntime>0) {
				choose = Random.Range (1f, 2f);
				if (choose <= 1.5) {
					Instantiate (EnemyMedium, spawnpos, Quaternion.identity);
				} else if (choose > 1.5 && choose <= 1.7) {
					Instantiate (EnemyEasy, spawnpos, Quaternion.identity);
				} else if (choose > 1.7 && choose <= 1.9) {
					if (GameObject.Find("FollowEnemy(Clone)") == false) {
						Instantiate (EnemyFollow, spawnpos, Quaternion.identity);
					} else{
						Instantiate (EnemyEasy, spawnpos, Quaternion.identity);
					}
				} else {
					Instantiate (Money, spawnpos, Quaternion.identity);
				}
			} else {
				choose = Random.Range (1f, 2f);
				if (choose <= 1.9) {
					Instantiate (EnemyEasy, spawnpos, Quaternion.identity);
				} else if (choose>1.9){
					Instantiate (Money, spawnpos, Quaternion.identity);
				}
			}
			spawntimer = spawntime;
		}
	}
		
		
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
	}
}
