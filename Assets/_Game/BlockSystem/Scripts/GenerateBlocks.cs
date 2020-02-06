using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour {
    [Header ("Block System")]

    public float xInit = -14; // tart position of blocks
    public float xEnd = 14; // end position of blocks
    public float xSpan = 4; //x offet
    public float ySpen = 4; // y offset
    private Vector3 newPositon; //Position for the section of blocks

    // Start is called before the first frame update
    void Start () {

        Color randomColor = Color.red; //Set default color of block to red
        //Check if color will change
        if (Random.Range (0, 50) > 25) {
            randomColor = Color.blue; //Set color of bloc to blue
        }
        Color randomColorGlow = randomColor;
        randomColorGlow.a = 0.34f;
        List<objectPooler> objToGenerate = BlockListPooler.blockList.objToGenerate; //Get blocks
        List<objectPooler> powerUp = BlockListPooler.blockList.powerUp; //Get powerups
        newPositon = transform.position; // Set default positon 
        float xValue = xInit; // Set starting position of block
        bool powerDone = false; //bool to check if powerup is done

        //Check if power up will produce in this section
        float powerUpChance = 100 - GameValues.values.getScore ();
        if (powerUpChance < 15) {
            powerUpChance = 15;
        }
        if ((Random.Range (0, 100) > (powerUpChance))) {
            powerDone = true;
        }
        bool canBoss = GameValues.values.Turns % 10 == 0; //Check if boss block can generate
        while (xValue <= xEnd) {
            if (canBoss) {
                //Condition to generate boss block
                if ((Random.Range (0, 100) > 75) || Mathf.Approximately (xValue, xEnd)) {
                    GameObject obj = Instantiate (objToGenerate[Mathf.FloorToInt (Random.Range (0, objToGenerate.Count - 0.1f))].getPooledObject ());
                    obj.transform.parent = transform;
                    obj.transform.localPosition = new Vector3 (xValue, 0, 0);
                    obj.SetActive (true);
                    SpriteRenderer[] objRenderers = obj.GetComponentsInChildren<SpriteRenderer> ();
                    objRenderers[0].color = randomColor;
                    objRenderers[1].color = randomColorGlow;
                    obj.GetComponent<BlockSystem> ().health = GameValues.values.Turns * 3;

                    obj.AddComponent<BossBlock> ();//Add boss block component to block
                    obj.GetComponent<BossBlock> ().addedComp ();//setup box block component
                    obj.tag = "BossBlock";//Change tag of block
                    return;
                }
                xValue += xSpan;
                Debug.Log (xValue + " " + xEnd);
                continue;
            }
            if (!powerDone && ((Random.Range (0, 100) > 75) || Mathf.Approximately (xValue, xEnd))) {
                GameObject obj = Instantiate (powerUp[Mathf.FloorToInt (Random.Range (0, powerUp.Count - 0.1f))].getPooledObject ());
                obj.transform.parent = transform;
                obj.transform.localPosition = new Vector3 (xValue, 0, 0);
                obj.SetActive (true);
                powerDone = true;
            } else if (Random.Range (0, 100) > 50 || (xValue == xEnd && transform.childCount < 1)) {;
                GameObject obj = Instantiate (objToGenerate[Mathf.FloorToInt (Random.Range (0, objToGenerate.Count - 0.1f))].getPooledObject ());
                obj.transform.parent = transform;
                obj.transform.localPosition = new Vector3 (xValue, 0, 0);
                obj.SetActive (true);
                SpriteRenderer[] objRenderers = obj.GetComponentsInChildren<SpriteRenderer> ();
                objRenderers[0].color = randomColor;
                objRenderers[1].color = randomColorGlow;
                obj.GetComponent<BlockSystem> ().health = GameValues.values.Turns;
            }
            xValue += xSpan;
        }
    }
    // Update is called once per frame
    void Update () {
        if (newPositon != transform.position) {
            //Move towards the position to move
            transform.position =
                Vector3.MoveTowards (transform.position, newPositon, 100 * Time.deltaTime);
        }
    }
    public void moveDown () {
        newPositon.y -= ySpen;
    }

    public void setnewPosition (Vector3 NPositon) {
        newPositon = NPositon;
    }
}