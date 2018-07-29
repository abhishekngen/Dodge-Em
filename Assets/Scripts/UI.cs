using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour {
	public GameObject Slideryh;
	public float slidevalue;
	public float slidevalue1;
	public GameObject Continue;
	public GameObject Restart;
	public GameObject Menu;
	public Text score;
	public GameObject Player;
	public GameObject EnemySpawn;
	public int scoreacc = 0;
	public float score1 = 0;
	string timedisp;
	public bool dead = false;
	// Use this for initialization
	void Start () {
		//Player = GameObject.FindGameObjectWithTag ("Player");
		if (PlayerPrefs.HasKey ("Sensitivity")) {
			Slideryh.GetComponent<Slider> ().value = PlayerPrefs.GetFloat ("Sensitivity");
		} else {
			Slideryh.GetComponent<Slider> ().value = 0.1f;
		}

		
	}
	void Awake(){
		
	}
	
	// Update is called once per frame
	void Update () {
		//slidevalue1 = GameObject.Find ("SensitivitySlider").GetComponent<Slider> ().value;
		if (Application.loadedLevel == 0 && GetComponent<UIMat>().play==true && Player.activeSelf == true) {
			if (Input.GetKey (KeyCode.Escape)) {
				Time.timeScale = 0;
				OtherMove playscript = Player.GetComponent<OtherMove> ();
				playscript.enabled = false;
				Continue.SetActive (true);
				Restart.SetActive (true);
				Menu.SetActive (true);
			}
		}
		
		/*score1 += Time.deltaTime;	
		scoreacc = Mathf.FloorToInt (score1);
		/*score1 = 0;
		score1 += Mathf.FloorToInt(Time.timeSinceLevelLoad);
		scoreacc += score1;*/
		/*timedisp = scoreacc.ToString ();
		score.text = "Score: " + timedisp;*/
	}
	public void Play(){
		OtherMove playscript = Player.GetComponent<OtherMove> ();
		playscript.enabled = true;
		Application.LoadLevel (0);
		Time.timeScale = 1;
	}
	public void DeathPlay(){
		Application.LoadLevel (0);
		Time.timeScale = 1;
	}
	public void Instr(){
		Application.LoadLevel (2);
	}
	public void Continuegame(){
		OtherMove playscript = Player.GetComponent<OtherMove> ();
		playscript.enabled = true;
		Continue.SetActive (false);
		Restart.SetActive (false);
		Menu.SetActive (false);
		Time.timeScale = 1;
	}
	public void MainMenu(){
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < Enemies.Length; i++) {
			Destroy (Enemies [i]);
		}
		Application.LoadLevel (0);
	}
	public void SensSlider(){
		/*OtherMove playscript = Player.GetComponent<OtherMove> ();
		playscript.speedaccel = slidevalue;*/
		slidevalue = Slideryh.GetComponent<Slider> ().value;
		PlayerPrefs.SetFloat ("Sensitivity", slidevalue);
		Debug.Log(PlayerPrefs.GetFloat("Sensitivity"));
	}

		
	
}
