using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateyh : MonoBehaviour {
	public float rotatef = 25f;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		transform.Rotate (0, 0, rotatef * Time.deltaTime);
	}
}
