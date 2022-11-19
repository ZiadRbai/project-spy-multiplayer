using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Player List")]
public class PlayerList : ScriptableObject
{
    public Dictionary<int, BasePlayer> roomList = new Dictionary<int, BasePlayer>();

    public void AddPlayerListing(int actorNumber, BasePlayer element)
    {
        roomList.Add(actorNumber, element);
    }

    public void RemovePlayerListing(int key)
    {
        roomList.Remove(key);
    }

    public bool ContainsKey(int key)
    {
        return roomList.ContainsKey(key);
    }

    public BasePlayer GetElement(int key)
    {
        return roomList[key];
    }

    public int GetRoomSize()
    {
        return roomList.Count;
    }

    public bool isEveryoneReady()
    {
        foreach (PlayerLobby p in roomList.Values)
        {
            if (!p.GetCustomProperty<bool>(CustomProperties.Ready))
            {
                return false;
            }
        }
        return true;
    }

    public void Clear()
    {
        roomList.Clear();
    }
}
