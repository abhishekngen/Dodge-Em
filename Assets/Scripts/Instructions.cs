using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Instructions : MonoBehaviour {
	private string avoidname, catchname;
	public GameObject Avoid, Catch;
	public Text Avoid1, Catch1;
	private GameObject Avoidfollow, Catchfollow;
	private int avoidcount = 0;
	private int catchcount = 0;
	private int bulgecount = 0;
	private float inc = 0f;
	private float monsurvival = 4.5f;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("tutval")) {
			if (PlayerPrefs.GetInt ("tutval") == 3) {
				Destroy (this.gameObject);
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Enemy") && avoidcount == 0) {
			Avoidfollow = GameObject.FindGameObjectWithTag ("Enemy");
			avoidcount++;
			Avoid.SetActive (true);
			avoidname = Avoidfollow.scene.name;
		}
		if (avoidcount == 1) {
			if (Avoidfollow == null) {
				Avoid.SetActive (false);
				avoidcount++;
			}
			Avoid.transform.position = Camera.main.WorldToScreenPoint (new Vector2(Avoidfollow.transform.position.x, Avoidfollow.transform.position.y + 0.8f));

		}
		if (GameObject.FindGameObjectWithTag ("Money") && catchcount == 0) {
			Catchfollow = GameObject.FindGameObjectWithTag ("Money");
			catchcount++;
			Catch.SetActive (true);
			catchname = Catchfollow.name;
		}
		if (catchcount == 1) {
			if (Catchfollow == null) {
				Catch.SetActive (false);
				catchcount++;
				if (PlayerPrefs.HasKey ("tutval")) {
					PlayerPrefs.SetInt ("tutval", PlayerPrefs.GetInt ("tutval") + 1);
				} else {
					PlayerPrefs.SetInt ("tutval", 1);
				}
			}
			Catch.transform.position = Camera.main.WorldToScreenPoint (new Vector2 (Catchfollow.transform.position.x, Catchfollow.transform.position.y + 0.6f));


		}		


	}
}
