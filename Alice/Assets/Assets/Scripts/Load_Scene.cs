using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour {


    public void Start()
    {
        
    }
    public void OnMouseButton()
    {
        SceneManager.LoadScene("Basement");
    }
}


