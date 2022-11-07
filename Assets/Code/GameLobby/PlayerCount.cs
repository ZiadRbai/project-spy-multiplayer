using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;


public class PlayerCount : MonoBehaviourPunCallbacks
{
    TMP_Text PlayerCountText;

    void Start()
    {
        PlayerCountText = GetComponent<TMP_Text>();
        InvokeRepeating("Refresh", 0f, 1f);
    }

    private void Refresh()
    {

        PlayerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }

    
}
