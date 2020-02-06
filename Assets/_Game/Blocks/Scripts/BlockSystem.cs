using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockSystem : MonoBehaviour {
    [Header ("Block Properties")]
    public float health = 1; //Health of the block
    private float fullhealth; //Full health;
    private TextMeshPro healthText; // Display of health
    private SpriteRenderer[] spriteRenderer; // Sprite Renederer Component
    private void Start () {
        healthText = GetComponentInChildren<TextMeshPro> (); //Get Child that will displa text;
        healthText.text = health.ToString ();
        fullhealth = health;
        spriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer> ();
    }
    private void OnCollisionEnter2D (Collision2D other) {
        //Check if the collider hit is a ball
        if (health <= 0) {
            return;
        }
        if (other.gameObject.tag == "Ball") {

            health--;
            healthText.text = health.ToString (); //Change Display

            Color newcolor = spriteRenderer[0].color;
            newcolor.g = 1 - (health / fullhealth);
            spriteRenderer[0].color = newcolor;
            newcolor.a = 0.34f;
            spriteRenderer[1].color = newcolor;
            //Condition to detroy block if health is less then 0
            if (health <= 0) {
                if (tag == "BossBlock") {
                    SoundHolder.soundHolder.backgroundAudio.pitch = 1;
                    int randomBallsToIncMax = GameValues.values.turns/5;
                    if(randomBallsToIncMax>10) randomBallsToIncMax=10;
                    int randomBallsToInc = (int)Mathf.CeilToInt(Random.Range(0.1f,randomBallsToIncMax));
                    FindObjectOfType<ChangePosition> ().BallsToIncrease+=randomBallsToInc;
                    ShowBallsIncreased.ballsIncreasedTweener.ShowCanvas(randomBallsToInc);
                }
                GameObject particle = ParticalPooler.particalPooler.playParticle (); //Get Partical
                particle.SetActive (true); //Activate partical
                particle.transform.position = transform.position; //Set partical position
                particle.GetComponent<ParticleSystem> ().Play (); //Play partical

                gameObject.SetActive (false); //Destroy block

            }
        }
    }

}