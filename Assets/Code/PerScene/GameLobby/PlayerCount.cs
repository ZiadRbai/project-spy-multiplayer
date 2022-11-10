using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PlayerCount : MonoBehaviourPunCallbacks
{
    TMP_Text PlayerCountText;

    void Awake()
    {
        PlayerCountText = GetComponent<TMP_Text>();
        Refresh();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Refresh();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
       Refresh();
    }

    private void Refresh()
    {
        PlayerCountText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }

    
}
