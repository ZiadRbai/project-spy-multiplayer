using UnityEngine;
using TMPro;
using System.Collections;
using Photon.Pun;

public class VotingResults : MonoBehaviour
{
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
        yield return new WaitForSeconds(timeBeforeResults);
        DisplayText(GetPlayerVotedOn());
        yield return new WaitForSeconds(timeAfterResults);
        if (PhotonNetwork.IsMasterClient)
        {
            GetComponent<MySceneManager>().ChangeRoomScene("GameRoom");
        }
    }
    

    private void DisplayText(string textTo)
    {
        textDisplay.text = textTo + " been voted out";
    }

    private string GetPlayerVotedOn()
    {
        foreach(BasePlayer bp in players.roomList.Values)
        {
            if (bp.GetCustomProperty<bool>(CustomProperties.isVotedOn))
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    bp.SetCustomProperty<bool>(CustomProperties.isVotedOn, false);
                    bp.SetCustomProperty<bool>(CustomProperties.isOut, true);
                }
                if (bp.isLocalPlayer())
                {
                    return "You have";
                }
                return bp.GetPlayerObject().NickName + " has";
            }
        }
        return "No one has";
    }
}
