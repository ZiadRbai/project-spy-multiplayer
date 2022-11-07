using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;



public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField joinInput;
    private ErrorPanel errorPanel;
    private PopUps popUpManager;
    private int roomCodeLength = 5;

    public void Awake()
    {
        popUpManager = GameObject.Find("PopUpManager").GetComponent<PopUps>();
        errorPanel = popUpManager.errorPanel;
        
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 1;
        PhotonNetwork.CreateRoom(RandomStringGenerator(roomCodeLength), roomOptions);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorPanel.DisplayError(message);
    }

    public void JoinRoom()
    {
        if    (joinInput.text.Length == roomCodeLength) { PhotonNetwork.JoinRoom(joinInput.text); }
        else if(joinInput.text.Length > roomCodeLength) { errorPanel.DisplayError("Room code too long"); }
        else if(joinInput.text.Length < roomCodeLength) { errorPanel.DisplayError("Room code too short"); }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        errorPanel.DisplayError(message);
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
