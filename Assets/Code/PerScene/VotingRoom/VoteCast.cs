using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VoteCast : MonoBehaviour
{
    [SerializeField] private PlayerList players;
    [SerializeField] private PlayerVoteManager pvm;

    List<int> voteList;

    void OnEnable()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GlobalCountdown.OnCountdownEnd += OrderVoteCast;
        }
    }
    void OnDisable()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GlobalCountdown.OnCountdownEnd -= OrderVoteCast;
        }
    }

    //Done by masterclient
    public void OrderVoteCast()
    {
        PhotonView photonView = GetComponent<PhotonView>();
        photonView.RPC("CastLocalVote", RpcTarget.All);
        Invoke("SetVotedOn", 2f);
    }

    //Done by the rest of the players
    [PunRPC]
    public void CastLocalVote()
    {
        if(pvm.GetVote() != null)
        {
            CustomProperties.LocalPlayer.SetLocalCustomProperty<int>(CustomProperties.Vote, pvm.GetVote().GetPlayerObject().ActorNumber);
        }
    }

    //Done by masterclient
    void SetVotedOn()
    {
        //set all voted ons to false
        foreach (PlayerVoting pv in players.roomList.Values)
        {
                pv.SetCustomProperty<bool>(CustomProperties.isVotedOn, false);
        }

        //Set the player voted on
        int key = GetWinnnerActorNumber();
        if (players.ContainsKey(key))
        {
            players.GetElement(key).SetCustomProperty<bool>(CustomProperties.isVotedOn, true);
            print(players.GetElement(key).GetPlayerObject().NickName);
        }

        GetComponent<MySceneManager>().ChangeRoomScene("ResultsRoom");
    }

    //Done by masterclient
    private int GetWinnnerActorNumber()
    {
        GatherVotes();
        var grouped = voteList.GroupBy(i => i);

        bool duplicated = false;
        int highest = 0;
        int keyHighest = -1;

        foreach (var grp in grouped)
        {
            if (grp.Count() == highest)
            {
                duplicated = true;
            }

            if (grp.Count() > highest)
            {
                duplicated = false;
                highest = grp.Count();
                keyHighest = grp.Key;
            }
        }

        if (duplicated)
        {
            print("DRAW or NO RESULT");
            return -1;
        }
        else
        {
            print("Voted on is ActorNumber: " + keyHighest);
            return keyHighest;
        }
    }

    //Done by masterclient
    private void GatherVotes()
    {
        voteList = new List<int>();
        foreach (PlayerVoting pv in players.roomList.Values)
        {
            voteList.Add(pv.GetCustomProperty<int>(CustomProperties.Vote));
        }
    }




}