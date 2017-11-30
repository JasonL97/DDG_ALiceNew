using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Controls : MonoBehaviour {

    public void OnMouseButton()
    {
        SceneManager.LoadScene("controls");
    }
}
