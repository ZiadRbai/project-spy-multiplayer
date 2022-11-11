using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class BasePlayerSpawner : MonoBehaviour
{
    [SerializeField] private BasePlayer basePlayer;
    public void PopulateRoom(Transform room, PlayerList playerList)
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            InstantiatePlayerListing(playerInfo.Value, room, playerList);
        }
    }
    public void InstantiatePlayerListing(Player player, Transform room, PlayerList playerList)
    {
        BasePlayer element = Instantiate(basePlayer, room);
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
