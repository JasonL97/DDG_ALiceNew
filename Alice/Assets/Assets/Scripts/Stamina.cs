using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {
    public Image visualStamina;
    public float currentStamina;
    public float minXValue;
    public float maxXvalue;
    public float cachedY;
    public float maxStamina = 100;
    public RectTransform StaminaTransform;
    public GameObject b_button;
    public GameObject Alice;
    // Use this for initialization
    void Start () {
        cachedY = StaminaTransform.position.y;
        maxXvalue = StaminaTransform.position.x - StaminaTransform.rect.width;
        minXValue = StaminaTransform.position.x;
        currentStamina = maxStamina;

    }
	
	// Update is called once per frame
	void Update () {
        if (maxStamina != 0)
        {
            HandleStamina();
            B_Button bb = b_button.GetComponent<B_Button>();
            if (bb.Boosting == true)
            {
                maxStamina = maxStamina - 1;
            }
        }
        if (maxStamina == 0)
        {
            B_Button bb = b_button.GetComponent<B_Button>();
            bb.Boosting = false;
            Player pl = Alice.GetComponent<Player>();
            pl.moveSpeed = 15;
        }
    }
    private void HandleStamina()
    {
        float currentXValue = MapValues(currentStamina, 0, maxStamina, minXValue, maxXvalue);
        print(minXValue);
        StaminaTransform.position = new Vector3(currentXValue, cachedY);
    }
    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
