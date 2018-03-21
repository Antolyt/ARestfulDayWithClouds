using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScorePresenter : MonoBehaviour {

    //[HideInInspector]public int score;
    public Text scoreText;
    public Text gameplayScoreText;

    public int waitTime;
    private float timeStemp;
    public UnityEvent action;

    // Use this for initialization
    void Start () {
        scoreText.text = gameplayScoreText.text;
        timeStemp = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1") && Time.time > timeStemp + waitTime)
        {
            if (action != null) action.Invoke();
            return;
            //SceneManager.LoadScene("Gameplay");
        }
	}
}
