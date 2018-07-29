using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMat : MonoBehaviour {

	public GameObject plusfive, camtrans, Bossspawn, Instr1, Instr2, Instructions, shopbutton;
	private bool camcolour = false, plus = false;
	private int camcount = 0;
	public Camera cam;
	public GameObject Restartpause, Continue;
	public GameObject selection, selection1;
	public Text choicetext;
	public bool highscstart = false;
	private bool scorereset = false;
	public string timedisp;
	public Text highscore;
	public GameObject highsc;
	public int scoreacc = 0;
	public bool settingsexit = false;
	public GameObject goback;
	public bool settingsstarted = false;
	public float settingsspeed = 100f;
	public GameObject senseslider;
	public GameObject sensetitle;
	public GameObject settingstitle;
	public int scoracc;
	public float score1;
	public Text scoredisp;
	public GameObject Score;
	public GameObject UIop;
	public GameObject SettingsBack;
	public GameObject Deadtext;
	public GameObject Restartbutton;
	public GameObject Menubutton;
	public GameObject EnemySpawnScene;
	public GameObject EnemySpawn;
	public GameObject Playbutton;
	public GameObject Settings;
	public GameObject TitleText;
	public GameObject rotateplayer;
	public GameObject playeracc;
	public GameObject playerprefab;
	private GameObject[] Enemies;
	private GameObject[] Money;
	public float exitspeed = 5f;
	public bool play = false;
	private bool inst = false;
	private float pushtime = 3f;
	private float pushsettings = 3f;

	// Use this for initialization
	void Awake(){
		
	}
	void Start () {
		
		EnemySpawnScene = GameObject.FindGameObjectWithTag ("EnemySpawn");
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("accel")) {
			if (PlayerPrefs.GetInt ("accel") == 0) {
				choicetext.text = "Touch";
			} else {
				choicetext.text = "Accelerometer";
			}
		}
		
		if (PlayerPrefs.HasKey ("camcol")) {
			Debug.Log ("Quack");
			if (PlayerPrefs.GetInt ("camcol") == 0) {
				Debug.Log ("Double Quack");
				cam.GetComponent<Camera> ().backgroundColor = Color.black;
				camcolour = true;
			} else {
				cam.GetComponent<Camera> ().backgroundColor = new Color (83f / 255f, 249f / 255f, 242f / 255f, 0f);
				camcolour = false;
			}
		}
		if (highscstart == true) {
			if(scoreacc>PlayerPrefs.GetInt("high_score") && PlayerPrefs.HasKey("high_score") == true){
				PlayerPrefs.SetInt("high_score", scoreacc);
				Debug.Log (PlayerPrefs.GetInt ("high_score"));
			}
			else if(PlayerPrefs.HasKey("high_score") == false){
				PlayerPrefs.SetInt("high_score", scoreacc);
				Debug.Log (PlayerPrefs.GetInt ("high_score"));
			}
			highsc.SetActive (true);
			highscore.text = "High Score: " + PlayerPrefs.GetInt ("high_score");
			highscstart = false;	
			
		}

		if (play == true) {
			if(pushtime>=0){
				Playbutton.transform.Translate (0, -exitspeed * Time.deltaTime, 0);
				Settings.transform.Translate (exitspeed*Time.deltaTime, -exitspeed * Time.deltaTime, 0);
				SettingsBack.transform.Translate (exitspeed*Time.deltaTime, -exitspeed * Time.deltaTime, 0);
				TitleText.transform.Translate (0, exitspeed * Time.deltaTime, 0);
                shopbutton.transform.Translate(-exitspeed * Time.deltaTime, -exitspeed * Time.deltaTime, 0);
				//rotateplayer.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0.005f, 0.005f));
				Destroy(rotateplayer);
				pushtime -= Time.deltaTime;
			}
			if (inst == true) {
				Instructions.SetActive (true);
				playeracc.SetActive (true);
				Destroy (EnemySpawnScene);
				Instantiate (EnemySpawn);
				Instantiate (Bossspawn);
				Score.SetActive (true);
				UI scorescript = UIop.GetComponent<UI> ();
				//scorescript.scoreacc = 0;
				//scorescript.score1 = 0;
				inst = false;
			}
			if (scorereset == true) {
				score1 = 0f;
				scoreacc = 0;
				scorereset = false;
			}
			score1 += Time.deltaTime;
			scoreacc = Mathf.FloorToInt (score1);
			timedisp = scoreacc.ToString ();
			scoredisp.text = "Score: " + timedisp;
		}
		if (settingsstarted == true && pushsettings>=0) {
			Playbutton.transform.Translate (0, -exitspeed * Time.deltaTime, 0);
			Settings.transform.Translate (exitspeed * Time.deltaTime, -exitspeed * Time.deltaTime, 0);
			SettingsBack.transform.Translate (exitspeed * Time.deltaTime, -exitspeed * Time.deltaTime, 0);
			TitleText.transform.Translate (0, exitspeed * Time.deltaTime, 0);
            shopbutton.transform.Translate(-exitspeed * Time.deltaTime, -exitspeed * Time.deltaTime, 0);
			//rotateplayer.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0.005f, 0.005f));
			Destroy (rotateplayer);
			sensetitle.SetActive (true);
			senseslider.SetActive (true);
			settingstitle.SetActive (true);
			goback.SetActive (true);
			selection.SetActive (true);
			selection1.SetActive (true);
			pushsettings -= Time.deltaTime;
		}
		if (settingsstarted == true && pushsettings < 0) {
			settingsstarted = false;
		}
		if (settingsexit == true && pushsettings >= 0) {
			/*sensetitle.SetActive (false);
			senseslider.SetActive (false);
			settingstitle.SetActive (false);
			goback.SetActive (false);
			Playbutton.transform.Translate (exitspeed * Time.deltaTime, exitspeed * Time.deltaTime, 0);
			Settings.transform.Translate (-exitspeed * Time.deltaTime, exitspeed * Time.deltaTime, 0);
			SettingsBack.transform.Translate (-exitspeed * Time.deltaTime, exitspeed * Time.deltaTime, 0);
			TitleText.transform.Translate (0, -exitspeed * Time.deltaTime, 0);
			/*sensetitle.transform.Translate (0, exitspeed * Time.deltaTime, 0);
			senseslider.transform.Translate (0, exitspeed * Time.deltaTime, 0);
			settingstitle.transform.Translate (0, exitspeed * Time.deltaTime, 0);
			goback.transform.Translate (0, -exitspeed * Time.deltaTime, 0);
			pushsettings -= Time.deltaTime;*/
			//pushsettings -= Time.deltaTime;
			Application.LoadLevel(0);
		}
		if (settingsexit == true && pushsettings < 0) {
			settingsexit = false;
		}

		
	}
	public void PlayAcc(){
		Enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for(int i = 0; i<Enemies.Length; i++){
			Destroy (Enemies [i]);
		}
		Money = GameObject.FindGameObjectsWithTag ("Money");
		for (int i = 0; i < Money.Length; i++) {
			Destroy (Money [i]);
		}
		GameObject[] Spawnholes = GameObject.FindGameObjectsWithTag ("Spawnhole");
		for (int i = 0; i < Spawnholes.Length; i++) {
			Destroy (Spawnholes [i]);
		}
		play = true;
		inst = true;
	}
	public void MainMenu(){ //currently not being used
		Enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < Enemies.Length; i++) {
			Destroy (Enemies [i]);
		}
		Money = GameObject.FindGameObjectsWithTag ("Money");
		for (int i = 0; i < Money.Length; i++) {
			Destroy (Money [i]);
		}

	}
	public void Restart(){

		Enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < Enemies.Length; i++) {
			Destroy (Enemies [i]);
		}
		Money = GameObject.FindGameObjectsWithTag ("Money");
		for (int i = 0; i < Money.Length; i++) {
			Destroy (Money [i]);
		}
		GameObject[] Spawnholes = GameObject.FindGameObjectsWithTag ("Spawnhole");
		for (int i = 0; i < Spawnholes.Length; i++) {
			Destroy (Spawnholes [i]);
		}
		EnemySpawnScene = GameObject.FindGameObjectWithTag ("EnemySpawn");
		Destroy (EnemySpawnScene);
		Instantiate (EnemySpawn);
		GameObject boss = GameObject.FindGameObjectWithTag ("quack");
		Destroy (boss);
		Instantiate (Bossspawn);
		if (playeracc.activeSelf == false) {
			playeracc.SetActive (true);
		} else {
			playeracc.transform.position = new Vector2 (0, 0);
			playeracc.GetComponent<OtherMove> ().enabled = true;
		}
		//OtherMove playscript = playeracc.GetComponent<OtherMove> ();
		//playscript.canmove = true;
		Destroy(Instr1);
		Destroy (Instr2);
		Restartbutton.SetActive (false);
		Menubutton.SetActive (false);
		Deadtext.SetActive (false);
		highsc.SetActive (false);
		Restartpause.SetActive (false);
		Continue.SetActive (false);
		//camtrans.transform.rotation = Quaternion.Euler(0, 0, 0);
		//cam.GetComponent<Camera> ().orthographicSize = 5;
		Time.timeScale = 1;
		UI scorescript = UIop.GetComponent<UI> ();
		scoreacc = 0;
		score1 = 0;
		timedisp = scoreacc.ToString ();
		scorereset = true;
        playeracc.GetComponent<AudioSource>().Play();
	}
	public void Settingsstart(){

		settingsstarted = true;
			
	}
	public void SettingsExit(){
		pushsettings = 3f;		
		settingsexit = true;
		//settingstarted = false;
	}
	public void HighScore(){
		Debug.Log ("Talk TO ME");
		if(scoreacc>PlayerPrefs.GetInt("high_score") && PlayerPrefs.HasKey("high_score") == true){
			PlayerPrefs.SetInt("high_score", scoreacc);
			Debug.Log (PlayerPrefs.GetInt ("high_score"));
		}
		else if(PlayerPrefs.HasKey("high_score") == false){
			PlayerPrefs.SetInt("high_score", scoreacc);
			Debug.Log (PlayerPrefs.GetInt ("high_score"));
		}
		highsc.SetActive (true);
		highscore.text = "High Score: " + PlayerPrefs.GetInt ("high_score");
		highscstart = false;	


					


	}
	public void InputChoice(){
		OtherMove playscript = playeracc.GetComponent<OtherMove> ();
		if (choicetext.text == "Accelerometer") {
			choicetext.text = "Touch";
			PlayerPrefs.SetInt ("accel", 0);

		} else {
			choicetext.text = "Accelerometer";
			PlayerPrefs.SetInt ("accel", 1);

		}
	}
	public void NightMode(){
		if (camcount == 0) {
			cam.GetComponent<Camera> ().backgroundColor = Color.black;
			PlayerPrefs.SetInt ("camcol", 0);
			camcount++;
		} else {
			cam.GetComponent<Camera> ().backgroundColor = new Color (83f / 255f, 249f / 255f, 242f / 255f, 0f);
			PlayerPrefs.SetInt ("camcol", 1);
			camcount--;
		}

	}
	public void PlusFive(){
		plusfive.SetActive (true);
		plus = true;

	}
    
	
		
}
