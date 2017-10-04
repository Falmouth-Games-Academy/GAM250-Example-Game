using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public Text playerScoreTxt;
    public Text playerLivesTxt;
    public PlayerManager player;

	
	// Update is called once per frame
	void Update () {
        playerScoreTxt.text = player.currentScore.ToString();
        playerLivesTxt.text = player.currentLives.ToString();
    }
}
