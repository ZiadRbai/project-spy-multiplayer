using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public GameSettings gameSettings;

    [SerializeField]
    private TMP_InputField joinInput, nameInput;

    public PopUpManager popUpManager;
    private int roomCodeLength = 5;

    [SerializeField]
    private StaticString RoomName;


    public void CreateRoom()
    {
        CustomProperties.LocalPlayer.SetLocalPlayerReady(nameInput.text);
        PhotonNetwork.CreateRoom(RoomName.value = CustomProperties.RandomStringGenerator(roomCodeLength), SetRoomOptions());
    }

    private RoomOptions SetRoomOptions()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = gameSettings.maxPlayers;

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
            CustomProperties.LocalPlayer.SetLocalPlayerReady(nameInput.text);

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
        RoomName.value = PhotonNetwork.CurrentRoom.Name;
        PhotonNetwork.LoadLevel("GameLobby");
    }
}


