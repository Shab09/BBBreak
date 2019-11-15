using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    [Header("Block System")]
    public List<GameObject> objToGenerate;
    public float xInit = -14;
    public float xEnd = 14;
    public float xSpan = 4;
    public float ySpen = 4;
    private Vector3 newPositon;

    // Start is called before the first frame update
    void Awake()
    {
        newPositon = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(newPositon!=transform.position){
            //Move towards the position to move
            transform.position =
                Vector3.MoveTowards (transform.position, newPositon, 100 * Time.deltaTime);
        }
    }
    public void moveDown(){
        newPositon.y -=ySpen;
    }
}
