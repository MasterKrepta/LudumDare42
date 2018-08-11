using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrinderTimer : MonoBehaviour {
    Grinder grinder;

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
		if(secondsRemaining <= 0) {
            //DROP;
            grinder.ActivateGrinder();
            //TODO: Place a small delay on the clock so it doenst auto roll over instantly. 
            ResetClock();
        }
        else {
            secondsRemaining -= Time.deltaTime;
        }
        FormatTimer(secondsRemaining);
	}

    void FormatTimer(float secondsRemaining) {
        string minutes = Mathf.Floor(secondsRemaining / 60).ToString("00");
        string seconds = (secondsRemaining % 60).ToString("00");

        txtTimeRemaining.text = "Time Remaining: " + string.Format("{0}:{1}", minutes, seconds);
    }

    void ResetClock() {
        secondsRemaining = timeToDrop;
        FormatTimer(secondsRemaining);
    }

    
}
