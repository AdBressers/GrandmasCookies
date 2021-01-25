using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlManager : MonoBehaviour
{

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    public static bool spawn;
    

    private Vector3 lastEndPosition;
    public static Vector3 border;

    void Awake()
    {

        lastEndPosition = levelPart_Start.Find("endpos").position;
        SpawnLevelPart();

        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }


        //Transform lastLevelPartTransform;
        //lastLevelPartTransform = SpawnLevelPart(levelPart_Start.Find("endpos").position);
        //lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("endpos").position);
        //lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("endpos").position);
        //lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("endpos").position);
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {

        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelartTransform.Find("endpos").position;
    }

    void Update()
    {
        border = lastEndPosition;
        if (spawn == true)
        {
            SpawnLevelPart();
            SpawnLevelPart();
            SpawnLevelPart();
            spawn = false;
        }
    }
}
