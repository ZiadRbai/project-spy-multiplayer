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

    private PopUps popUpManager;
    private int roomCodeLength = 5;
    [SerializeField] private byte maxPlayers;

    public void Awake()
    {
        popUpManager = GameObject.Find("PopUpManager").GetComponent<PopUps>();
        
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;

        PhotonNetwork.NickName = usernameSet();
        PhotonNetwork.CreateRoom(RandomStringGenerator(roomCodeLength), roomOptions);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        popUpManager.DisplayPopUpMessage(message, "Close");
    }

    public void JoinRoom()
    {
        if    (joinInput.text.Length == roomCodeLength) 
        {
            PhotonNetwork.NickName = usernameSet();
            PhotonNetwork.JoinRoom(joinInput.text); 
        }
        else { popUpManager.DisplayPopUpMessage("Room code has to be 5 characters long", "Close"); }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        popUpManager.DisplayPopUpMessage(message, "Close");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameLobby");
    }

    string RandomStringGenerator(int length, bool numbersOnly = false)
    {
        string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz1234567890";
        string generated_string = "";

        int range = 0;
        if (numbersOnly) { range = chars.Length - 10; } else { range = 0; }

        for(int i=0; i<length; i++)
        {
            generated_string += chars[Random.Range(range, chars.Length)];
        }
        return generated_string;
    }
     
    string usernameSet()
    {
        if(!string.IsNullOrEmpty(nameInput.text))
        {
            return nameInput.text;
        }
        else
        {
            return "Guest#" + RandomStringGenerator(4, true);
        }
    }



}
