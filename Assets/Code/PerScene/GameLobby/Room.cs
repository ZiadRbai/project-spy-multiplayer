using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Room : MonoBehaviourPunCallbacks
{
    public PlayerList playerList;
    public BasePlayerSpawner playerSpawner;

    private void Awake()
    {
        playerList.Clear();
        GetCurrentRoomPlayers();
    }

    private void GetCurrentRoomPlayers()
    {   
        playerSpawner.PopulateRoom(transform, playerList);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        playerSpawner.InstantiatePlayerListing(newPlayer, transform, playerList);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        playerSpawner.RemovePlayerListing(otherPlayer, playerList);
    }

    public static void IsOpenRoom(bool value)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = value;
        }
    }
}
