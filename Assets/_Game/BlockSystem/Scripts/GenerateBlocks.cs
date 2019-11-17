using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour {
    [Header ("Block System")]
    public List<GameObject> objToGenerate;
    public float xInit = -14;
    public float xEnd = 14;
    public float xSpan = 4;
    public float ySpen = 4;
    private Vector3 newPositon;

    // Start is called before the first frame update
    void Awake () {
        newPositon=transform.position;
        float xValue = xInit;
        while (xValue <= xEnd) {
            if (Random.Range (0, 100) > 50) {
                GameObject obj = Instantiate (objToGenerate[Random.Range (0, objToGenerate.Count - 1)]);
                obj.transform.parent = transform;
                obj.transform.localPosition = new Vector3 (xValue, 0, 0);
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

    public void setnewPosition(Vector3 NPositon){
        newPositon = NPositon;
    }
}