using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusFiveyh : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 0.9) {
			this.gameObject.SetActive (false);
		}
		
	}
}
