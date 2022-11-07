using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

}