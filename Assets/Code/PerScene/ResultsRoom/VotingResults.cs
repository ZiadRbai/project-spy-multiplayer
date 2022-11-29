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
    private BasePlayer playerToOut;

    void Start()
    {
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        
        yield return new WaitForSeconds(timeBeforeResults);
        DisplayText(GetPlayerVotedOn(), false);
        yield return new WaitForSeconds(timeAfterResults);
        VotePlayerOut(playerToOut);
        CheckGameState(playerToOut);
        yield return new WaitForSeconds(timeAfterResults/4);

        if (/*gameSettings.currentRound == 0 || */ CustomProperties.GetRoomCustomProperty<bool>(CustomProperties.GameOver))
        {
            DisplayText(WinningRole(), true);
            yield return new WaitForSeconds(timeAfterResults);
            CustomProperties.SetRoomCustomProperty<int>(CustomProperties.WinningRole, (int)eRole.Spy);
            CustomProperties.SetRoomCustomProperty<bool>(CustomProperties.GameOver, false);
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
                return "Spies have won";
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
                if (bp.isLocalPlayer())
                {
                    playerToOut = bp;
                    return "You have";
                }
                playerToOut = bp;
                return bp.GetPlayerObject().NickName + " has";
            }
        }
        playerToOut = null;
        return "No one has";
    }
    
    private void CheckGameState(BasePlayer pleyar)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (CustomProperties.GetRoomCustomProperty<int>(CustomProperties.ActivePlayers) < 3)
            {
                CustomProperties.SetRoomCustomProperty<int>(CustomProperties.WinningRole, (int)eRole.Spy);
                CustomProperties.SetRoomCustomProperty<bool>(CustomProperties.GameOver, true);
                return;
            }

            if (pleyar !=null && pleyar.GetCustomProperty<int>(CustomProperties.Role) == (int)eRole.Spy)
            {
                CustomProperties.SetRoomCustomProperty<int>(CustomProperties.WinningRole, (int)eRole.Agent);
                CustomProperties.SetRoomCustomProperty<bool>(CustomProperties.GameOver, true);
                return;
            }
        }
    }

    private void VotePlayerOut(BasePlayer player)
    {
        if (PhotonNetwork.IsMasterClient && player != null)
        {
            CustomProperties.CurrentRoom.IncrementCustomProperty(CustomProperties.ActivePlayers, -1);
            player.SetCustomProperty<bool>(CustomProperties.isOut, true);
            player.SetCustomProperty<bool>(CustomProperties.isVotedOn, false);
            Debug.Log("Done");
            
        }
    }
}
