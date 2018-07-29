using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColour : MonoBehaviour {
	public GameObject player, restartdead, mainmenu, deadtext, uiop, burst, burst1;
	public Transform playertrans;
	private bool vibrate = false;
	private int vibratecount = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (vibrate == true && vibratecount<15) {
			playertrans.Translate (new Vector2 (Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
			vibratecount++;
				
		}
		/*if(vibratecount>=15){
			player.transform.position = new Vector3(0, 0, 0);
			player.SetActive(false);
			restartdead.SetActive(true);
			mainmenu.SetActive(true);
			deadtext.SetActive(true);
			UIMat ui = uiop.GetComponent<UIMat>();
			ui.highscstart = true;
			vibrate = false;
			vibratecount = 0;
		}*/
		
		
	}
	public void DeathLook(Transform enemy){
		
		transform.LookAt (playertrans);
		GetComponent<Camera> ().orthographicSize = 2;
		vibrate = true;
		Instantiate (burst, playertrans.position, Quaternion.identity);
		Instantiate (burst1, playertrans.position, Quaternion.identity);
		StartCoroutine (Vibrate());
	}
	IEnumerator Vibrate(){
		/*bool down = true;
		playertrans.Translate (new Vector2 (0, 1));
		for (int i = 0; i < 15; i++) {
			if (down) {
				playertrans.Translate (new Vector2 (0, -2));
				down = false;
			} else {
				playertrans.Translate (new Vector2 (0, 2));
				down = true;
			}

			yield return null;
		}*/


		player.transform.position = new Vector3 (0, 0, 0);
		player.SetActive (false);
		yield return new WaitForSeconds (5);
		Continued ();
	}
	void Continued(){
		
		restartdead.SetActive (true);
		mainmenu.SetActive (true);
		deadtext.SetActive (true);
		UIMat ui = uiop.GetComponent<UIMat> ();
		ui.highscstart = true;
		vibrate = false;
		vibratecount = 0;
	}
			
}
