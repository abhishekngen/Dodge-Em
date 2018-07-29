using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriExit : MonoBehaviour {
	public GameObject tri;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		EnemyEasyAI triboss = tri.GetComponent<EnemyEasyAI> ();
		if (triboss.Timer <= 0) {
			CircleCollider2D coll = GetComponent<CircleCollider2D> ();
			coll.enabled = false;
		}
	}
}
