using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoss : MonoBehaviour {
	public float speed;
	public GameObject Player, enemyspawn;
	public float life = 10f;
	private bool follow = true;
	private Vector2 exit;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
        enemyspawn = GameObject.FindGameObjectWithTag("EnemySpawn");
        EnemySpawn e = enemyspawn.GetComponent<EnemySpawn>();
        e.enabled = false;
	}
	void Update(){
		life -= Time.deltaTime;
		if (life <= 0) {
			follow = false;
			if (transform.position.y > Camera.main.ScreenToWorldPoint (new Vector2 (0, Screen.height / 2)).y) {
				exit = new Vector2 (0, 1);
			} else {
				exit = new Vector2 (0, -1);
			}
		}
			
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (follow) {	
			transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, speed * Time.deltaTime);
		} else {
			transform.Translate (exit * speed * Time.deltaTime);
		}
	}
	void OnBecameInvisible(){
        EnemySpawn e = enemyspawn.GetComponent<EnemySpawn>();
        e.enabled = true;
		Destroy(this.gameObject);
	}
}
