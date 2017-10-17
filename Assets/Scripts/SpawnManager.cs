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

    public int currentSpawnIndex = 0;

    [SerializeField]
    Transform[] spawnPoints;

    public bool spawnDone = false;
    public int currentSpawnCount = 0;
    public float currentCoolDown;

    void Start()
    {
        SpawnData currentSpawnData = spawnData[currentSpawnIndex];
        currentCoolDown = currentSpawnData.coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnData.Count > 0 && !spawnDone)
        {
            SpawnData currentSpawnData = spawnData[currentSpawnIndex];
            if (currentSpawnCount>currentSpawnData.amountToSpawn)
            {
                currentSpawnIndex++;
                currentSpawnCount = 0;
                if (loopSpawning && currentSpawnIndex>spawnData.Count-1)
                {
                    currentSpawnIndex = 0;
                    currentCoolDown = spawnData[currentSpawnIndex].coolDown;
                }   
                else if (!loopSpawning)
                {
                    spawnDone = true;
                }
            }

            if (currentCoolDown < 0.0f)
                Spawn(currentSpawnData);
            else
                currentCoolDown -= Time.deltaTime;
        }
    }

    void Spawn(SpawnData spawnData)
    {
        Instantiate(spawnData.prefab, spawnPoints[Random.Range(0, spawnPoints.Length - 1)]);
        currentSpawnCount++;
        currentCoolDown = spawnData.coolDown;
    }
}
