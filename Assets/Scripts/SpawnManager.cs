using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject astroidPrefab;
    public float astroidTime;
    public float astroidCoolDown=5.0f;

    public GameObject enemyPrefab;
    public float enemyTime;
    public float enemyCoolDown=5.0f;

    public Transform[] spawnPoints;

    // Update is called once per frame
    void Update() {
        if (Time.timeSinceLevelLoad < astroidTime)
        {
            if (astroidCoolDown < 0.1f)
            {
                Transform currentSpawnPoint = spawnPoints[Random.Range(0, 2)];
                Instantiate(astroidPrefab, currentSpawnPoint.position, Quaternion.identity);
                astroidCoolDown = 5.0f;
            }

            astroidCoolDown -= Time.deltaTime;
        }
        else if (Time.timeSinceLevelLoad > astroidTime && Time.timeSinceLevelLoad < enemyTime)
        {
            if (enemyCoolDown<0.1f)
            {
                int currentSpawn = Random.Range(0, 2);
                Transform currentSpawnPoint = spawnPoints[currentSpawn];
                GameObject obj=(GameObject)Instantiate(enemyPrefab, currentSpawnPoint.position, Quaternion.identity);
                EnemyController enemyController = obj.GetComponent<EnemyController>();
                if (currentSpawn==0)
                {
                    enemyController.direction = new Vector2(0.5f, -1.0f);
                }
                else if (currentSpawn==1)
                {
                    enemyController.direction = new Vector2(0.0f, -1.0f);
                }
                else if (currentSpawn==2)
                {
                    enemyController.direction = new Vector2(-0.5f, -1.0f);
                }
                enemyController.Move();
                enemyCoolDown = 5.0f;
            }

            enemyCoolDown -= Time.deltaTime;
        }

	}
}
