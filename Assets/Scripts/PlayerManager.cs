using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public int currentLives = 3;

    public GameObject explosionPrefab;
    public GameObject player;
    public GameObject currentExplosion;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
        if (currentLives<0)
        {
            //end game
        }
	}

    public void PlayerHit()
    {
        currentLives--;
        player.SetActive(false);
        currentExplosion=(GameObject)Instantiate(explosionPrefab, player.transform.position, Quaternion.identity);
    }

    public void ShowPlayer()
    {
        player.SetActive(true);
        Destroy(currentExplosion);
    }
}
