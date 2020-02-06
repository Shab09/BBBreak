using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootBall : MonoBehaviour {
    [Header ("Ball Properties")]
    public float BallSpeed = 50;
    public float BallCount = 1;
    public float BallDamage=1;
    private objectPooler balls;
    private TextMeshProUGUI ballText;
    private Camera main;

    //Values that will be used to calculate Direction
    private Vector3 tar;
    private Vector3 dif;
    private float distance;
    private Vector3 dir;
    private bool aimStarted;
    private Vector3 startposition;
    private Touch touch;
    [Header ("Line Properties")]
    //Values for line 
    private GameObject line;
    private LineRenderer lineRenderer;
    public Material linemat;

    private bool dontShoot;

    // Start is called before the first frame update
    void Awake () {
        main = Camera.main; //Assign Camera
        balls = GetComponentInChildren<objectPooler> (); //Get ball object pooler
        ballText = GetComponentInChildren<TextMeshProUGUI> (); //Get text for balls

        line = new GameObject (); //Create new Gameobject for line
        line.transform.position = transform.position;
        lineRenderer = line.AddComponent<LineRenderer> (); //Add line renderer to line
        line.name = "line"; //Change line name

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition (1, Vector2.zero);
        lineRenderer.material = linemat; // Set line material
        //lineRenderer.widthMultiplier = 0.4f; //Set width of line
        line.SetActive (false); //Deactivate line
    }

    // Update is called once per frame
    void Update () {
        
        if (Input.touchCount > 0) {
            touch = Input.GetTouch (0);

            //Check if aim started
            if ((touch.phase == TouchPhase.Began) &&
                !GameValues.values.InShoot && 
                !EventSystem.current.IsPointerOverGameObject () &&
                Time.timeScale == 1) {
                dontShoot = true;
                line.SetActive (true);
                lineRenderer.SetPosition (0, Vector3.zero + transform.position); //Set Starting position of line

                startposition = main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));

                aimStarted = true;

                //Calculate The Position to launch balls
                tar = main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));
                dif = startposition - tar;
                distance = dif.magnitude;
                dir = dif / distance;
                lineRenderer.SetPosition (1, distance / 10 * (dir.normalized * BallSpeed) + transform.position); //Set end position of line

            }
            if ((touch.phase == TouchPhase.Moved) && aimStarted) {

                if (main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y)).y < startposition.y) {
                    lineRenderer.gameObject.SetActive (true);
                    //Calculate The Position to launch balls
                    tar = main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));
                    dif = startposition - tar;
                    distance = dif.magnitude;
                    dir = dif / distance;
                    lineRenderer.SetPosition (1, distance / 10 * (dir.normalized * BallSpeed) + transform.position); //Set end position of line
                    dontShoot = false;
                } else {
                    lineRenderer.gameObject.SetActive (false);
                    dontShoot = true;
                }
            }

            if (!dontShoot && (touch.phase == TouchPhase.Ended) && !GameValues.values.InShoot && aimStarted) {

                GameValues.values.InShoot = true; //Set that ball is in shoot

                //Shoot Number of balls
                StartCoroutine (launchBalls (0));

                line.SetActive (false);
                aimStarted = false;

            }
        }
    }

    IEnumerator launchBalls (int ballsLaunched) {
        Vector3 launchPosition = transform.position;
        //Shoot balls until ball count is reached
        while (ballsLaunched != BallCount) {
            ballText.text = "x" + (BallCount - ballsLaunched);
            GameObject newBall = balls.getPooledObject (); //Get pooled balls
            newBall.transform.position = launchPosition; //set position to player positon
            newBall.SetActive (true); //Activate ball
            newBall.GetComponent<Rigidbody2D> ().velocity = dir.normalized * BallSpeed; // apply calculated speed 
            yield return new WaitForSeconds (0.03f);
            ballsLaunched++; //increase number of balls shot
        }
        ballText.gameObject.SetActive (false);
        yield return null;
    }

    public void displayText () {
        ballText.gameObject.SetActive (true);
        ballText.text = "x" + BallCount;
    }
}