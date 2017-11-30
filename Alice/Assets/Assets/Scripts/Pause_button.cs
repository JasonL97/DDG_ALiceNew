using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_button : MonoBehaviour {
    public GameObject pauseCanvas;
    public bool isTrue = false;
    private float savedTimeScale;

    // Use this for initialization
    void Start () {
        savedTimeScale = Time.timeScale;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseButton()
    {
        if (isTrue == true)
        {
            pauseCanvas.SetActive(false);
            isTrue = false;
            Time.timeScale = savedTimeScale;
        }
        else if (isTrue == false)
        {
            pauseCanvas.SetActive(true);
            isTrue = true;
            Time.timeScale = 0;
        }
    }
}
