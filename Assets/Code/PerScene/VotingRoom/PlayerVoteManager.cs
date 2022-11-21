using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerVoteManager : MonoBehaviour
{
    [SerializeField] private PlayerList playerList;
    [HideInInspector] private PlayerVoting currentVote = null;

    void ResetVotes()
    {
        foreach(PlayerVoting pv in playerList.roomList.Values)
        {
            pv.ChangeHighlightTo(false);
        }
    }

    public void HighlightThis(PlayerVoting pv)
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

    public PlayerVoting GetVote()
    {
        return currentVote;
    }


}
