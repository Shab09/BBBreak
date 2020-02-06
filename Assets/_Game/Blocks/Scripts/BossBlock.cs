using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBlock : MonoBehaviour {
    public bool XRotate;
    SpriteRenderer[] objRenderers;
    Color[] randomColors = new Color[] {Color.cyan,Color.magenta,Color.yellow}; 
    // Start is called before the first frame update
    public void addedComp () {
        objRenderers = GetComponentsInChildren<SpriteRenderer> ();
        StartCoroutine(newColor());
        XRotate=false;
        if(Random.Range(0,100)>50){
            XRotate=true;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (XRotate) {
            transform.Rotate (3, 0, 0);
        } else {
            transform.Rotate (0, 3, 0);
        }
    }
    IEnumerator newColor () {
        while (true) {
            yield return new WaitForSeconds (0.5f);
            int random = Mathf.FloorToInt(Random.Range(0,2.99f));
            Color randomColor = randomColors[random];
            objRenderers[0].color = randomColor;
            randomColor.a = 0.34f;
            objRenderers[1].color = randomColor;
        }
    }
}