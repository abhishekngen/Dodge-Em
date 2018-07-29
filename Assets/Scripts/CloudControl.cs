using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour {
	static CloudControl instance;
	public float ypos;
	public GameObject cloud1;
	public GameObject cloud2;
	public GameObject cloud3;
	private Vector3 spawnpos;
	public float spawntimer = 5f;
	private float spawntime = 0;
	private bool confirm = false;
	// Use this for initialization
	void Awake(){
		
	}
	void Start () {
		spawntime = spawntimer;
		
	}
	
	// Update is called once per frame
	void Update () {
		while (confirm == false) {
			ypos = Random.Range (0f, Screen.height);
			Vector3 test = Camera.main.ScreenToWorldPoint (new Vector3 (0, ypos, 0));

			if (Mathf.Abs(spawnpos.y - test.y) < 3) {
				confirm = false;
			} else {
				confirm = true;
			}
		}
		float xpos = Screen.width;
		spawnpos = Camera.main.ScreenToWorldPoint (new Vector3 (xpos, ypos, 0));
		spawnpos = new Vector3 (spawnpos.x + 2, spawnpos.y, 0);
		if (spawntime <= 0) {
			int choose = Random.Range (1, 3);
			if (choose == 1) {
				Instantiate (cloud1, spawnpos, Quaternion.identity);
			}
			if (choose == 2) {
				Instantiate (cloud2, spawnpos, Quaternion.identity);
			}
			if (choose == 3) {
				Instantiate (cloud3, spawnpos, Quaternion.identity);
			}
			spawntime = spawntimer;
			confirm = false;
		}
		spawntime -= Time.deltaTime;

		
	}
}
