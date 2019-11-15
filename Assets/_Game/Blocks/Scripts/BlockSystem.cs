using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockSystem : MonoBehaviour
{
    [Header("Block Properties")]
    public float health=1;//Health of the block
    private TextMeshPro healthText; // Display of health
    private void Start() {
        healthText = GetComponentInChildren<TextMeshPro>();//Get Child that will displa text;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        //Check if the collider hit is a ball
        if(other.gameObject.tag=="Ball"){
            
            health--;//Decrease health
            healthText.text = health.ToString();//Change Display

            //Condition to detroy block if health is less then 0
            if(health<=0){
                Destroy(gameObject);//Destroy block
            }
        }
    }
}
