using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrinderTimer : MonoBehaviour {
    Grinder grinder;
    bool isRunning = true;
    [SerializeField] TMP_Text txtTimeRemaining;

    [SerializeField] float timeToDrop = 15;
    [SerializeField] float secondsRemaining;
    
    // Use this for initialization
    void Start () {
        grinder = GetComponent<Grinder>();
        secondsRemaining = timeToDrop;
	}
	
	// Update is called once per frame
	void Update () {
        if (isRunning) {
            if (secondsRemaining <= 0) {
                //DROP;
                txtTimeRemaining.text = "00:00";
                grinder.ActivateGrinder();
                //TODO: Place a small delay on the clock so it doenst auto roll over instantly. 
                ResetClock();
            }
            else {
                secondsRemaining -= Time.deltaTime;
            }
            FormatTimer(secondsRemaining);
        }
        else {
            txtTimeRemaining.text = "00:00";
        }
        
    }

    void FormatTimer(float secondsRemaining) {
        string minutes = Mathf.Floor(secondsRemaining / 60).ToString("00");
        string seconds = (secondsRemaining % 60).ToString("00");

        //txtTimeRemaining.text = "Time Remaining: " + string.Format("{0}:{1}", minutes, seconds);
        txtTimeRemaining.text = string.Format("{0}:{1}", minutes, seconds);

        if(secondsRemaining < 10) {
            txtTimeRemaining.GetComponent<Animator>().SetBool("Hurry", true);
        }
    }

    public void ResetClock() {
        isRunning = true;
        txtTimeRemaining.GetComponent<Animator>().SetBool("Hurry", false);
        secondsRemaining = timeToDrop;
        FormatTimer(secondsRemaining);
    }

    public void StopClock() {
        isRunning = false;
    }

    
}
