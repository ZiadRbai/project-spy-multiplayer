using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Player List")]
public class PlayerList : ScriptableObject
{
    public Dictionary<int, PlayerElement> roomList = new Dictionary<int, PlayerElement>();

    public void AddPlayerListing(int actorNumber, PlayerElement element)
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

    public PlayerElement GetElement(int key)
    {
        return roomList[key];
    }

    public bool isEveryoneReady()
    {
        foreach (PlayerElement p in roomList.Values)
        {
            if (!p.GetReadyStatus())
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
