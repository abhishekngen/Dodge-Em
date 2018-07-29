using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour {
    public GameObject Title, Settings, Settingsback, Playbutt, rotateplayer, Shopbutt;
    public GameObject Customtitle, customplayer, rtarrow, leftarrow, goback;
    public GameObject Unlock, Use, Info;
    public GameObject cube1, cube2, cube3;
    public Text req;
    private bool shopstarted = false, shoprunning = false, organise = false;
    private float pushsettings = 3f;
    private int selectsq;
    public int maxselect = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (shopstarted && pushsettings>=0)
        {
            Playbutt.transform.Translate(0, -1000 * Time.deltaTime, 0);
            Title.transform.Translate(0, 1000 * Time.deltaTime, 0);
            Settings.transform.Translate(1000 * Time.deltaTime, -1000 * Time.deltaTime, 0);
            Settingsback.transform.Translate(1000 * Time.deltaTime, -1000 * Time.deltaTime, 0);
            Shopbutt.transform.Translate(-1000 * Time.deltaTime, -1000 * Time.deltaTime, 0);
            Destroy(rotateplayer);
            Customtitle.SetActive(true);
            customplayer.SetActive(true);
            rtarrow.SetActive(true);
            leftarrow.SetActive(true);
            goback.SetActive(true);
            pushsettings -= Time.deltaTime;
        }
        if(shopstarted && pushsettings < 0)
        {
            shopstarted = false;
            
        }
        if (shoprunning && organise == false)
        {
            if (PlayerPrefs.HasKey("SquareSelect"))
            {
                selectsq = PlayerPrefs.GetInt("SquareSelect");
            }
            else
            {
                PlayerPrefs.SetInt("SquareSelect", 1);
                selectsq = 1;
            }
            organise = true;

        }
        if(shoprunning && organise == true)
        {
            if(selectsq ==1)
            {
                cube1.SetActive(true);
            }
            else
            {
                cube1.SetActive(false);
            }
            if(selectsq == 2)
            {
                cube2.SetActive(true);
            }
            else
            {
                cube2.SetActive(false);
            }
            if(selectsq == 3)
            {
                cube3.SetActive(true);
            }
            else
            {
                cube3.SetActive(false);
            }
            if(selectsq == 1)
            {
                leftarrow.SetActive(false);
            }
            else
            {
                leftarrow.SetActive(true);
            }
            if(selectsq == maxselect)
            {
                rtarrow.SetActive(false);
            }
            else
            {
                rtarrow.SetActive(true);
            }
            if(selectsq == 1 && PlayerPrefs.GetInt("SquareSelect") != selectsq)
            {
                Use.SetActive(true);
            }
            else if(selectsq == 2 && PlayerPrefs.HasKey("sq2unlock")&&PlayerPrefs.GetInt("SquareSelect") != selectsq)
            {
                Use.SetActive(true);
            }
            else if(selectsq == 3 && PlayerPrefs.HasKey("sq3unlock") && PlayerPrefs.GetInt("SquareSelect") != selectsq)
            {
                Use.SetActive(true);
            }
            else
            {
                Use.SetActive(false);
            }
            if(selectsq == 2 && PlayerPrefs.HasKey("sq2unlock") == false)
            {
                Unlock.SetActive(true);
                Info.SetActive(true);
                req.text = "Requires High Score of 80";
            }
            else if(selectsq == 3 && PlayerPrefs.HasKey("sq3unlock")== false)
            {
                Unlock.SetActive(true);
                Info.SetActive(true);
                req.text = "Requires High Score of 130";
            }
            else
            {
                Unlock.SetActive(false);
                Info.SetActive(false);
            }
               
        }

		
	}

    public void ShopStart()
    {
        shopstarted = true;
        shoprunning = true;
    }
    public void NextSq()
    {
        selectsq++;
    }
    public void PrevSq()
    {
        selectsq--;
    }
    public void Exit()
    {
        //PlayerPrefs.SetInt("SquareSelect", selectsq);
        Application.LoadLevel(0);
    }
    public void UseSq()
    {
        PlayerPrefs.SetInt("SquareSelect", selectsq);
    }
    public void UnlockSq()
    {
        if(selectsq == 2)
        {
            if (PlayerPrefs.HasKey("high_score"))
            {
                if (PlayerPrefs.GetInt("high_score") >= 80)
                {
                    PlayerPrefs.SetInt("sq2unlock", 1);
                }
            }
        }
        else if(selectsq == 3)
        {
            if (PlayerPrefs.HasKey("high_score"))
            {
                if (PlayerPrefs.GetInt("high_score") >= 130)
                {
                    PlayerPrefs.SetInt("sq3unlock", 1);
                }
            }
        }
    }
}
