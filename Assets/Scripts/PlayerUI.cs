using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour,Observer {

    [SerializeField]
    Text playerScoreTxt;
    [SerializeField]
    Text playerLivesTxt;

    public void OnNotify(EventData data)
    {
        PlayerData playerData = data as PlayerData;
        playerScoreTxt.text = playerData.currentScore.ToString();
        playerLivesTxt.text = playerData.currentLives.ToString();
    }
}
