using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class BasePlayerSpawner : MonoBehaviour
{
    [SerializeField] private BasePlayer basePlayer;
    [SerializeField] private bool showLocalPlayer = true;
    public void PopulateRoom(Transform room, PlayerList playerList)
    {
        List<Player> outPlayers = new List<Player>();
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            //if (!showLocalPlayer && playerInfo.Value.IsLocal) 
            //    continue;
            if(CustomProperties.GetCustomProperty<bool>(CustomProperties.isOut, playerInfo.Value))
            {
                outPlayers.Add(playerInfo.Value);
            }
            else
            {
                InstantiatePlayerListing(playerInfo.Value, room, playerList);

            }
        }
        for (int i = 0; i < outPlayers.Count; i++)
        {
            InstantiatePlayerListing(outPlayers[i], room, playerList);
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
