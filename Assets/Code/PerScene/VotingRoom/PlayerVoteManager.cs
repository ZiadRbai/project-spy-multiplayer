using UnityEngine;

public class PlayerVoteManager : MonoBehaviour
{
    [SerializeField] private PlayerList playerList;
    private PlayerVoting currentVote = null;
    private bool votingOver = false;


    void ResetVotes()
    {
        foreach(PlayerVoting pv in playerList.roomList.Values)
        {
            pv.ChangeHighlightTo(false);
        }
    }

    public void HighlightThis(PlayerVoting pv)
    {
        if (!votingOver)
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

    void OnEnable()
    {
        GlobalCountdown.OnCountdownEnd += DisableVoting;
    }
    void OnDisable()
    {
        GlobalCountdown.OnCountdownEnd -= DisableVoting;
    }

    void DisableVoting()
    {
        votingOver=true;
    }

}
