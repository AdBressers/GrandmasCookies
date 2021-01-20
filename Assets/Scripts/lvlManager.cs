using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlManager : MonoBehaviour
{

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_Hole;
    [SerializeField] private Transform levelPart_Ob;



    // Start is called before the first frame update
    void Awake()
    {
        Transform lastLevelPartTransform;
        lastLevelPartTransform = SpawnLevelPart(levelPart_Start.Find("endpos").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("endpos").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("endpos").position);
        lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("endpos").position);
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart_Hole, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
