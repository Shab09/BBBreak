using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues : MonoBehaviour
{
    public static GameValues values;//Globel refernce to values
    private float score = 0;//Score to e displayed
    public bool inShoot=false;//If te player has shot the ball
    public bool InShoot{get{return inShoot;} set {inShoot=value;}} // Reference to the inShoot boolean
    // Start is called before the first frame update
    void Start()
    {
        if (values == null) {
            DontDestroyOnLoad (gameObject);
            values = this;
        } else {
            Destroy (gameObject);
        }
    }

    public void setScore(float points){
        score+=points; // Increase scoreby number of points
    }

}
