using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Button : MonoBehaviour {

    public GameObject player;
    public bool Boosting = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
   
	}

    public void OnButtonDown()
    {
        Stamina pls = player.GetComponent<Stamina>();
        if (pls.maxStamina != 0)
        {
            if (Boosting == false)
            {
                Player pl = player.GetComponent<Player>();
                pl.moveSpeed = 100f;
                Boosting = true;

            }
        }


        else if (Boosting == true)
        {
            Player pl = player.GetComponent<Player>();
            pl.moveSpeed = 20f;
            Boosting = false;
        }
    }
  
}
