using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour {
    [Header ("Ball Properties")]
    public float BallSpeed = 50;
    public float BallCount = 1;
    private objectPooler balls;
    private Camera main;

    //Values that will be used to calculate Direction
    private Vector3 tar;
    private Vector3 dif;
    private float distance;
    private Vector3 dir;

    // Start is called before the first frame update
    void Awake () {
        main = Camera.main;
        balls = GetComponentInChildren<objectPooler> ();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (0) && !GameValues.values.InShoot) {

            //Calculate The Position to launch balls
            tar = main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, main.transform.position.z));
            dif = tar - transform.position;
            distance = dif.magnitude;
            dir = dif / distance;

            GameValues.values.InShoot = true; //Set that ball is in shoot
            //Shoot Number of balls
            StartCoroutine(launchBalls(0));
        }
    }

    IEnumerator launchBalls (int ballsLaunched) {
        //Shoot balls until ball count is reached
        while (ballsLaunched != BallCount) {
            GameObject newBall = balls.getPooledObject (); //Get pooled balls
            newBall.transform.position = transform.position;//set position to player positon
            newBall.SetActive (true);//Activate ball
            newBall.GetComponent<Rigidbody2D> ().velocity = dir.normalized * BallSpeed; // apply calculated speed 
            
            yield return new WaitForSeconds(0.075f);
            ballsLaunched++;//increase number of balls shot
        }
        yield return null;
    }
}