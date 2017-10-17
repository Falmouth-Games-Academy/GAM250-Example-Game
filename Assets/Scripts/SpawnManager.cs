using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="SpawnData",menuName ="GAM250/Example/Spawn",order =1)]
public class SpawnData:ScriptableObject
{
    [SerializeField]
    public GameObject prefab;
    [SerializeField]
    public float coolDown;
    [SerializeField]
    public int amountToSpawn;
}

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    List<SpawnData> spawnData = new List<SpawnData>();

    [SerializeField]
    bool loopSpawning = false;

    int currentSpawnIndex = 0;

    [SerializeField]
    Transform[] spawnPoints;

    bool spawnDone = false;
    int currentSpawnCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (spawnData.Count > 0 && !spawnDone)
        {
            SpawnData currentSpawnData = spawnData[currentSpawnIndex];
            if (currentSpawnData.amountToSpawn>currentSpawnCount)
            {
                currentSpawnIndex++;
                currentSpawnCount = 0;
                if (loopSpawning && currentSpawnIndex>spawnData.Count)
                {
                    currentSpawnIndex = 0;
                }   
                else
                {
                    spawnDone = true;
                }

                Spawn(currentSpawnData);
            }
        }
    }

    void Spawn(SpawnData spawnData)
    {
        GameObject obj=(GameObject)Instantiate(spawnData.prefab, spawnPoints[Random.Range(0, spawnPoints.Length - 1)]);
        currentSpawnCount++;
    }
}
