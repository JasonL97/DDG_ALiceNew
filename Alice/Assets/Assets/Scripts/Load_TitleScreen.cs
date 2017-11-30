using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnMouseButton()
    {
        SceneManager.LoadScene("title_screen");
    }
}
