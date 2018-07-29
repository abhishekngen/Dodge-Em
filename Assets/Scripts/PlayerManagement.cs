using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour {
    public GameObject sqpl1, sqpl2, sqpl3;
    public GameObject sqr1, sqr2, sqr3;
    public GameObject UIop;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UIMat ui = UIop.GetComponent<UIMat>();
        if(ui.play == true)
        {
            Destroy(this.gameObject);
        }
        if (PlayerPrefs.HasKey("SquareSelect"))
        {
            if (PlayerPrefs.GetInt("SquareSelect") == 1)
            {
                sqpl1.SetActive(true);
                sqr1.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("SquareSelect") == 2)
            {
                sqpl2.SetActive(true);
                sqr2.SetActive(true);
            }
            else if(PlayerPrefs.GetInt("SquareSelect") == 3)
            {
                sqr3.SetActive(true);
                sqpl3.SetActive(true);
            }
        }
        else
        {
            sqpl1.SetActive(true);
            sqr1.SetActive(true);
        }
		
	}
}
