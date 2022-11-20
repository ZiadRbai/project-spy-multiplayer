using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerVoteManager : MonoBehaviour
{
    [SerializeField] private PlayerList playerList;
    [HideInInspector] private PlayerVoting currentVote;

    void Awake()
    {
        ResetVotes();
    }

    void ResetVotes()
    {
        foreach(PlayerVoting pv in playerList.roomList.Values)
        {
            if (!pv.isLocalPlayer())
            {
                pv.ChangeHighlightTo(false);
            }
        }
    }

    public void HighlightThis(PlayerVoting pv)
    {
        if (!pv.isLocalPlayer())
        {
            ResetVotes();
            if (pv == currentVote)
            {
                currentVote = null;
                pv.ChangeHighlightTo(false);
                return;
            }
            currentVote = pv;
            pv.ChangeHighlightTo(true);
        }
    }

    public PlayerVoting GetVote()
    {
        return currentVote;
    }


}
