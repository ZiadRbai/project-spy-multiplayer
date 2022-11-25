using UnityEngine;
using TMPro;
using System.Collections;
using Photon.Pun;
using System;

public class VotingResults : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private PlayerList players;
    [SerializeField] private TMP_Text textDisplay;
    [Space(10)]
    [SerializeField] private float timeBeforeResults;
    [SerializeField] private float timeAfterResults;

    void Start()
    {
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        
        RoundManager.DecreaseRounds();
        yield return new WaitForSeconds(timeBeforeResults);
        DisplayText(GetPlayerVotedOn(), false);
        yield return new WaitForSeconds(timeAfterResults);

        if (gameSettings.currentRound == 0 || CustomProperties.GetRoomCustomProperty<bool>(CustomProperties.GameOver))
        {
            DisplayText(WinningRole(), true);
            yield return new WaitForSeconds(timeAfterResults);
            GetComponent<MySceneManager>().ChangeRoomScene("GameLobby");
        }
        else
        {
            GetComponent<MySceneManager>().ChangeRoomScene("GameRoom");
        }
    }

    private string WinningRole()
    {
        switch ((eRole)CustomProperties.GetRoomCustomProperty<int>(CustomProperties.WinningRole))
        {
            case eRole.Agent:
                return "Agents have won";
            case eRole.Spy:
                return "Spy have won";
            case eRole.Intern:
                return "Agents have won";
            default:
                return "No one won";
        }
        
    }


    private void DisplayText(string textTo, bool isComplete)
    {
        if (isComplete)
        {
            textDisplay.text = textTo;
        }
        else
        {
            textDisplay.text = textTo + " been voted out";
        }
    }

    private string GetPlayerVotedOn()
    {
        foreach(BasePlayer bp in players.roomList.Values)
        {
            if (bp.GetCustomProperty<bool>(CustomProperties.isVotedOn))
            {
                VotePlayerOut(bp);
                if (bp.isLocalPlayer())
                {
                    return "You have";
                }
                SpyisOut(bp);
                return bp.GetPlayerObject().NickName + " has";
            }
        }
        return "No one has";
    }

    private void SpyisOut(BasePlayer pleyar)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (pleyar.GetCustomProperty<int>(CustomProperties.Role) == (int)eRole.Spy)
            {
                CustomProperties.SetRoomCustomProperty<int>(CustomProperties.WinningRole, (int)eRole.Agent);
                CustomProperties.SetRoomCustomProperty<bool>(CustomProperties.GameOver, true);
            }
        }
    }

    private void VotePlayerOut(BasePlayer player)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            player.SetCustomProperty<bool>(CustomProperties.isVotedOn, false);
            player.SetCustomProperty<bool>(CustomProperties.isOut, true);
        }
    }
}
