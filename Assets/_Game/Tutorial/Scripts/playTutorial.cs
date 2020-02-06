using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTutorial : MonoBehaviour {
    public Animator tutorial;
    int firstRun = 0; // variable to check if first run

    void Start () {
        //Get player prefs of first run
        firstRun = PlayerPrefs.GetInt ("savedFirstRun");
        //Check first run values
        if (firstRun == 0) {
            Debug.Log ("Getting run");
            PlayerPrefs.SetInt ("savedFirstRun", 1);
            tutorial.SetInteger ("firstGame", 0);
            tutorial.Play ("Tutorial");
        }
    }
    void Update () {
        //Check if it is the first run
        if (firstRun == 0) {
            //Check if there is a click or touch
            if (Input.touchCount > 0 || Input.GetMouseButtonDown (0)) {
                //stop the animation
                tutorial.Play ("Idle");
                tutorial.SetInteger ("firstGame", 1);
            }
        }
    }

    public void enableTutorial () {
        firstRun = 0;
        tutorial.SetInteger ("firstGame", 0);
        tutorial.Play ("Tutorial");
    }
}