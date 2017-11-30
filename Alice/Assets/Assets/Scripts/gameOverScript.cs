using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour {

    public void OnMouseButton()
    {
        SceneManager.LoadScene("title_screen");
    }
}
