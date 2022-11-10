using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;



public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private  TMP_InputField joinInput, nameInput;

    [SerializeField] 
    private byte maxPlayers;

    public PopUpManager popUpManager;
    private int roomCodeLength = 5;


    public void CreateRoom()
    {
        CustomProperties.LocalPlayer.SetLocalPlayerProperties(nameInput.text);
        PhotonNetwork.CreateRoom(CustomProperties.RandomStringGenerator(roomCodeLength), SetRoomOptions());
    }

    private RoomOptions SetRoomOptions()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;

        return roomOptions;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        popUpManager.DisplayPopUpMessage(message, "Close");
    }

    public void JoinRoom()
    {
        if(joinInput.text.Length == roomCodeLength) 
        {
            CustomProperties.LocalPlayer.SetLocalPlayerProperties(nameInput.text);
            PhotonNetwork.JoinRoom(joinInput.text); 
        }
        else 
        {
            popUpManager.DisplayPopUpMessage("Room code has to be 5 characters long", "Close"); 
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        popUpManager.DisplayPopUpMessage(message, "Close");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameLobby");
    }
}


