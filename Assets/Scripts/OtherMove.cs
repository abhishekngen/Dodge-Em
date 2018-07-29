using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMove : MonoBehaviour {
    private float movecool = 1.0f;
    public GameObject Down, Up, Right, Left;
	private Vector3 deltamove;
	public float deltaspeed = 0.3f;
	private float deltax, deltay;
	public bool canmove = true;
	public GameObject cam, burst, burst1;
	public bool accel = true;
	private Vector2 touchposition, lastpos;
	public GameObject UIop;
	public float speed = 0.75f;
	public float speedaccel = 0.5f;
	public float maxvelocity = 2f;
	public Vector2 Movement;
	private Rigidbody2D rb;
	public GameObject Restart;
	public GameObject Menu;
	public GameObject Deadtext;
    private float LeftTimer = 0f, RightTimer = 0f, UpTimer = 0f, DownTimer = 0f;
	private int vibrate = 0;
    private AudioSource audiomain;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		UI uiscript = UIop.GetComponent<UI> ();
        lastpos = transform.position;
        audiomain = GetComponent<AudioSource>();
        audiomain.Play();
		/*if (PlayerPrefs.HasKey ("Sensitivity")) {
			speedaccel = PlayerPrefs.GetFloat ("Sensitivity");
		}*/
	}
	void Update(){
       
		if (PlayerPrefs.HasKey ("Sensitivity")) {
			speedaccel = PlayerPrefs.GetFloat ("Sensitivity");
			speed = PlayerPrefs.GetFloat ("Sensitivity") / 3;
			if (speed > 1.5f) {
				speed = 1.5f;
			}
		}
		float hval = Input.GetAxis ("Horizontal");
		float vval = Input.GetAxis ("Vertical");
	    Vector2 mousepos = Input.mousePosition;
		mousepos = Camera.main.ScreenToWorldPoint (mousepos);
        
		transform.position = Vector2.Lerp (transform.position, mousepos, speed);
        float currvelocityx = (Mathf.Abs(transform.position.x - lastpos.x)) / Time.deltaTime;
        float currvelocityy = (Mathf.Abs(transform.position.y - lastpos.y)) / Time.deltaTime;
        /*if(PlayerPrefs.GetInt("accel") == 1 || PlayerPrefs.HasKey("accel") == false)
        {
            currvelocityx = Mathf.Abs(rb.velocity.x);
            currvelocityy = Mathf.Abs(rb.velocity.y);
            
        }*/
        /*if (currvelocityx > 2 && transform.position.x > lastpos.x)
        {
            Left.SetActive(true);
        }
        else
        {
            Left.SetActive(false);
            
        }
        if(currvelocityx > 2 && transform.position.x < lastpos.x)
        {
            Right.SetActive(true);
        }
        else
        {
            Right.SetActive(false);
            
        }
        if(currvelocityy > 2 && transform.position.y > lastpos.y)
        {
            Down.SetActive(true);
        }
        else
        {
            Down.SetActive(false);
            
        }
        if(currvelocityy > 2 && transform.position.y < lastpos.y)
        {
            Up.SetActive(true);
        }
        else
        {
            Up.SetActive(false);
            
        }
        lastpos = transform.position;*/
        

    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (PlayerPrefs.GetInt("accel") == 1 || PlayerPrefs.HasKey("accel") == false) {
			Movement = new Vector2 (Input.acceleration.x * speedaccel, Input.acceleration.y * speedaccel);
		} else {
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
				touchposition = Input.GetTouch (0).position;
				touchposition = Camera.main.ScreenToWorldPoint (touchposition);
				transform.position = Vector2.Lerp (transform.position, touchposition, speed);
				//deltax = Input.GetTouch (0).deltaPosition.x;
				//deltay = Input.GetTouch (0).deltaPosition.y;
				//float x = Input.touches[0].deltaPosition.x*deltaspeed*Time.deltaTime;
				//float y = Input.touches [0].deltaPosition.y * deltaspeed * Time.deltaTime;
				//rb.AddForce (new Vector2 (x, y));
			}

		}
		
		if (PlayerPrefs.GetInt ("accel") == 1 || PlayerPrefs.HasKey ("accel") == false) {
			rb.AddForce (Movement);
		}
		if (rb.velocity.y > maxvelocity) {
			rb.velocity = new Vector2 (rb.velocity.x, maxvelocity);

		}
		if (rb.velocity.y < -maxvelocity) {
			rb.velocity = new Vector2 (rb.velocity.x, -maxvelocity);
		}
		if (rb.velocity.x > maxvelocity) {
			rb.velocity = new Vector2 (maxvelocity, rb.velocity.y);
		}
		if (rb.velocity.x < -maxvelocity) {
			rb.velocity = new Vector2 (-maxvelocity, rb.velocity.y);
		}
        
	}
	void OnCollisionEnter2D(Collision2D other){


		if(other.gameObject.tag == "Enemy"){
			Time.timeScale = 0;
			//canmove = false;
			UIMat uiscript1 = UIop.GetComponent<UIMat> ();
			CameraColour camzoom = cam.GetComponent<CameraColour> ();
			//camzoom.DeathLook (other.gameObject.transform);
			//StartCoroutine (Vibrate ());
			Restart.SetActive (true);
			Menu.SetActive (true);
			Deadtext.SetActive (true);
			transform.position = new Vector3 (0, 0, 0);
			uiscript1.highscstart = true;
            audiomain.Stop();
            //cam.transform.position = this.transform.position;
            //cam.GetComponent<Camera> ().orthographicSize = 2;
            GetComponentInChildren<TrailRenderer>().Clear();
            
            this.gameObject.SetActive (false);

		}
	}
	IEnumerator Vibrate(){
		while(vibrate<10){
			transform.Translate (new Vector2 (Random.Range (0f, 1f), Random.Range (0f, 1f)));
			vibrate++;
			yield return new WaitForSeconds (1f);
		}
	}
    
		
		
}
