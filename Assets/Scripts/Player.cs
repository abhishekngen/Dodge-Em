using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float Speed = 2;
	public bool upbool = false;
	public bool downbool = false;
	public float spedx = 0;
	public float spedy = 0;
	bool downmovmnt = false;
	public GameObject boundaryy1;
	public GameObject boundaryy2;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
//		BoundaryCheck boundarycheck = boundaryy1.GetComponent<BoundaryCheck> ();
//		BoundaryCheck1 boundarycheck1 = boundaryy2.GetComponent<BoundaryCheck1> ();
		if (Input.GetKey (KeyCode.UpArrow)) {
			spedy = 1;
			downmovmnt = false;
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			spedy = -1;
			downmovmnt = true;
		} else {
			spedy = 0;
			downmovmnt = false;
		}
		/*if (spedy == 1) {
			if (Input.GetKey (KeyCode.DownArrow)) {
				spedy = -1;
			}
		}*/
		if (Input.GetKey (KeyCode.RightArrow)) {
				spedx = 1;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
				spedx = -1;
		} else {
				spedx = 0;
		}
		Move (spedx, spedy);	
		/*if (boundarycheck.invis == true) {
		}
			if (transform.position.y > boundarycheck.invispos.y) {
				transform.position = new Vector2 (transform.position.x, boundarycheck.invispos.y);
		}
		if (boundarycheck1.invis==true){
				if (transform.position.y < boundarycheck1.invispos.y) {
					transform.position = new Vector2 (transform.position.x, boundarycheck1.invispos.y);
				}
		}*/
			

		


		
		
		
		
		}
	public void Move(float spedirx, float spediry){
		transform.Translate (spedirx * Speed * Time.deltaTime, spediry * Speed * Time.deltaTime, 0);
	}


}
