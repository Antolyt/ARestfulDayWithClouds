using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public int startTime = 3;
    public float startTimeStemp;
    public Text CountDownText;
    public float TimeScaler = 1;

    public UnityEvent action;

	// Use this for initialization
	void Start () {
        startTimeStemp = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        int time = Mathf.RoundToInt(startTime + (startTimeStemp - Time.time) * TimeScaler);
        if(time < 0)
        {
            if (action != null) action.Invoke();
            return;
        }
        CountDownText.text = time.ToString();
	}
}
