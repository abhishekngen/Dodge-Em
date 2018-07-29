using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleShoot : MonoBehaviour {
	public GameObject Tribullet, enemyspawn, Triboss;
	public float spawntimer = 5f;
	private float spawntime = 5f;
	// Use this for initialization
	void Start () {
		enemyspawn = GameObject.FindGameObjectWithTag ("EnemySpawn");
		enemyspawn.GetComponent<EnemySpawn> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawntime <= 0) {
			Instantiate (Tribullet, transform.position, transform.parent.rotation);
			spawntime = spawntimer;
		}
		spawntime -= Time.deltaTime;
		EnemyEasyAI Tri = Triboss.GetComponent<EnemyEasyAI> ();
		if (Tri.Timer <= 0) {
			enemyspawn.GetComponent<EnemySpawn> ().enabled = true;
		}
		
	}
	void OnBecameInvisible(){
		
	}
}
