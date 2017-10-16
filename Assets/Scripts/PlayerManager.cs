using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerData:EventData
{
    public int currentLives;
    public int currentScore;
}

public class PlayerManager : Subject {

    [SerializeField]
    PlayerData playerData = new PlayerData();
    [SerializeField]
    GameObject explosionPrefab;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject currentExplosion;

	// Use this for initialization
	void Start ()
    {
        //Attach any observers
        AddObserver(GameObject.Find("GameUI").GetComponent<PlayerUI>());
        Notify(playerData);
	}
	
	// Update is called once per frame
	void Update () {
        if (playerData.currentLives < 0)
        {
            //end game
        }
	}

    public void PlayerHit()
    {
        playerData.currentLives--;
        player.SetActive(false);
        currentExplosion=(GameObject)Instantiate(explosionPrefab, player.transform.position, Quaternion.identity);
        Notify(playerData);
    }

    public void ShowPlayer()
    {
        player.SetActive(true);
        Destroy(currentExplosion);
    }

    public void AddScore(int score)
    {
        playerData.currentScore += score;
        Notify(playerData);
    }
}
