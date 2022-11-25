using UnityEngine;
using Photon.Pun;

public class TimerEnds : MonoBehaviour
{
    public enum nextAction {GoVote, GoTalk, GoLobby}
    [SerializeField] public nextAction whatNext;
    void OnEnable()
    {
        GlobalCountdown.OnCountdownEnd += ActionToTake;

    }

    void OnDisable()
    {
        GlobalCountdown.OnCountdownEnd -= ActionToTake;
    }

    void ActionToTake()
    {
        switch (whatNext)
        {
            case nextAction.GoVote:
                GetComponent<MySceneManager>().ChangeRoomScene("VotingRoom");
                break;
            case nextAction.GoTalk:
                GetComponent<MySceneManager>().ChangeRoomScene("GameRoom");
                break;
            case nextAction.GoLobby:
                GetComponent<MySceneManager>().ChangeRoomScene("GameLobby");
                break;
            default:
                break;
        }
    }
}

