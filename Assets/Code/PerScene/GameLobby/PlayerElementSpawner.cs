using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerElementSpawner : MonoBehaviour
{
    [SerializeField] private PlayerElement playerElement;
    public void PopulateRoom(Transform room, PlayerList playerList)
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            InstantiatePlayerListing(playerInfo.Value, room, playerList);
        }
    }
    public void InstantiatePlayerListing(Player player, Transform room, PlayerList playerList)
    {
        PlayerElement element = Instantiate(playerElement, room);
        if (element != null)
        {
            element.SetPlayerInfo(player);
            playerList.AddPlayerListing(player.ActorNumber, element);
        }
    }

    public void RemovePlayerListing(Player player, PlayerList playerList) 
    {
        int key;
        if (playerList.ContainsKey(key = player.ActorNumber))
        {
            Destroy(playerList.GetElement(key).gameObject);
            playerList.RemovePlayerListing(key);
        }
    }

   
}
