using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class RoundManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text textDisplay;
    [SerializeField] string preText;
    [SerializeField] GameSettings gameSettings;

    public void Awake()
    {
        RefreshRound();
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        if(propertiesThatChanged.ContainsKey(CustomProperties.CurrentRound))
        {
            gameSettings.currentRound = (int)propertiesThatChanged[CustomProperties.CurrentRound];
            RefreshRound();
        }
    }

    private void RefreshRound()
    {
        textDisplay.text = preText + (gameSettings.totalRounds - gameSettings.currentRound + 1);
    }
}
