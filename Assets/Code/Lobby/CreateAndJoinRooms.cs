using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;



public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField joinInput;

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(RandomStringGenerator(5));
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameLobby");
    }


    string RandomStringGenerator(int length)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        string generated_string = "";

        for(int i=0; i<length; i++)
        {
            generated_string += chars[Random.Range(0, chars.Length)];
        }
        return generated_string;
    }


}
