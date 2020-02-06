using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocity : MonoBehaviour {
    public float constSpeed = 50;
    private Rigidbody2D rb;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        sound = GetComponentInChildren<AudioSource> ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        rb.velocity = rb.velocity.normalized * constSpeed;
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Block" || other.gameObject.tag == "BossBlock")
            sound.Play ();
    }
}