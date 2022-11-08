using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerList : MonoBehaviourPunCallbacks
{
    private Transform playerList;
    [SerializeField] private PlayerElement playerElement;
    private List<PlayerElement> listingsList = new List<PlayerElement>();
    private Dictionary<int, PlayerElement> listings = new Dictionary<int, PlayerElement>();

    private void Awake()
    {
        playerList = transform;
        GetCurrentRoomPlayers();
    }

    private void GetCurrentRoomPlayers()
    {
        foreach(KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int key;
        if (listings.ContainsKey(key = otherPlayer.ActorNumber))
        { 
            Destroy(listings[key].gameObject);
            listings.Remove(key);
        }
    }

    private void AddPlayerListing(Player player)
    {
        PlayerElement element = Instantiate(playerElement, playerList);
        if (element != null)
        {
            element.SetPlayerInfo(player);
            listings.Add(player.ActorNumber, element);
        }
    }
}
