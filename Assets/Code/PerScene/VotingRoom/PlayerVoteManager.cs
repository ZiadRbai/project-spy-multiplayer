using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoteManager : MonoBehaviour
{
    [SerializeField] private PlayerList playerList;

    void Awake()
    {
        ResetVotes();
    }

    void ResetVotes()
    {
        foreach(PlayerVoting pv in playerList.roomList.Values)
        {
            pv.SwitchHighlight(false);
        }
    }

    public void HighlightThis(PlayerVoting pv)
    {
        ResetVotes();
        pv.SwitchHighlight(true);
    }

}
