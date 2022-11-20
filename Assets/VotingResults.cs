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
        textDisplay.text = textTo + " has been voted out";
    }

    private string GetPlayerVotedOn()
    {
        foreach(BasePlayer bp in players.roomList.Values)
        {
            if (bp.GetCustomProperty<bool>(CustomProperties.isVotedOn) && !bp.GetCustomProperty<bool>(CustomProperties.isOut))
            {
                bp.SetCustomProperty<bool>(CustomProperties.isOut, true);
                return bp.GetPlayerObject().NickName;
            }
        }
        return "No one";
    }



}
