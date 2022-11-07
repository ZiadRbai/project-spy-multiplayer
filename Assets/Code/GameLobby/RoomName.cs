using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class RoomName : MonoBehaviourPunCallbacks
{

    public void Start()
    {
        GetComponent<TMP_Text>().text = PhotonNetwork.CurrentRoom.Name;
    }
}
