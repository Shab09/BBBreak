using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseBall : MonoBehaviour
{
    public ChangePosition BallHolderRefernce;
    private void Start() {
        BallHolderRefernce = FindObjectOfType<ChangePosition>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Ball"){
            BallHolderRefernce.BallsToIncrease = BallHolderRefernce.BallsToIncrease+ 1 ;
            gameObject.SetActive(false);
        }
    }
}
