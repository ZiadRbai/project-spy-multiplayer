using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;


public class PlayerNumber : MonoBehaviourPunCallbacks
{
    TMP_Text PlayerNumberDisplay;

    void Start()
    {
        PlayerNumberDisplay = GetComponent<TMP_Text>();
        InvokeRepeating("Refresh", 0f, 1f);
    }

    private void Refresh()
    {

        PlayerNumberDisplay.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }

    
}
