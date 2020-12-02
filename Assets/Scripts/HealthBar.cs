using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject  HealthTextUI;
    Text HealthText;

    void Start() {
        HealthText = HealthTextUI.GetComponent<Text>();
    }

    // void Update() {
    //     Debug.Log(Convert.ToInt32(HealthText.text));
    //     int len = Convert.ToInt32(HealthText.text);
    //     transform.localScale -= new Vector3(len,0,0);

    //     // int len = Convert.ToInt32(HealthText.text) / 100 * 420;
    //     // transform.localScale = new Vector3(len , 0, 0);    
    // }


    
}
