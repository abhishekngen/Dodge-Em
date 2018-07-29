using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {
	public float speed = 5f;
	public static CloudMove instance;
	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad (this.gameObject);


	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void FixedUpdate(){
		transform.Translate (-speed * Time.deltaTime, 0, 0);
	}
	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
}
