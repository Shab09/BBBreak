using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockListPooler : MonoBehaviour
{
    public static BlockListPooler blockList;
    public List<objectPooler> objToGenerate;
    public List<objectPooler> powerUp;
    // Start is called before the first frame update
    void Awake()
    {
        blockList =this;   
    }
}
