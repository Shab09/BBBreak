using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour {
    private float currBallCount = 0; //Amount balls that hit colldier
    private bool firstHit = true;
    private Vector3 positionToMove;
    public ShootBall ballcount; //Reference to the total number of balls
    private float ballsToIncrease = 0; //Number of balls to increase when turn ends
    public float BallsToIncrease { set { ballsToIncrease = value; } get { return ballsToIncrease; } }

    private void Awake () {
        positionToMove = ballcount.gameObject.transform.position;
    }
    private void OnTriggerEnter2D (Collider2D other) {
        //Check if hit colldier is ball
        if (other.tag == "Ball") {

            //Check if the first ball hit
            if (firstHit) {
                Vector3 tempPosition = ballcount.gameObject.transform.position; //Temp Veriable to store new position
                tempPosition.x = other.transform.position.x; //Change value of x to new x
                positionToMove = (tempPosition); //Set value to move towards
                firstHit = false; //Firt hit has been registered
            }
            currBallCount++; //Increase the number of balls that hit collider
            other.gameObject.SetActive (false);
            //Check if number of hits is equal to total balls 
            if (currBallCount == ballcount.BallCount) {
                StartCoroutine(endturn()); //End turn after  a wait
            }
        }
    }
    private void Update () {
        //Check if current positon is equal to the posiion to move
        if (positionToMove != ballcount.gameObject.transform.position) {

            //Move towards the position to move
            ballcount.gameObject.transform.position =
                Vector3.MoveTowards (ballcount.gameObject.transform.position, positionToMove, 100 * Time.deltaTime);

        }
    }

    IEnumerator endturn () {
        yield return new WaitForSeconds (0.25f);
        ballcount.BallCount += ballsToIncrease; // Increase nuber of balls according to collected powerup
        ballsToIncrease = 0; // Reset balls to increase 
        GameValues.values.inShoot = false; //Can shoot again
        currBallCount = 0; //Reset counter
        firstHit = true; //Reset first hit

        //Move all current block system down
        foreach (GameObject system in GameObject.FindGameObjectsWithTag ("BlockSystem")) {
            system.GetComponent<GenerateBlocks> ().moveDown ();
        }

        BlockSystemGenerator.blockSystemGenerator.Genrate();
    }
}