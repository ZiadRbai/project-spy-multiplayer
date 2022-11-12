
using UnityEngine;

public class StartGame :  MonoBehaviour, IButton
{
    public PlayerList playerList;
    public PopUpManager popUpManager;
    public void OnClick()
    {
        if (playerList.isEveryoneReady())
        {
            ChangeRooms();
        }
        else
        {
            popUpManager.DisplayPopUpMessage("Not all players are ready", "Close");
        }
    }

    private void ChangeRooms()
    {
        GameObject.FindGameObjectWithTag("PhotonView").GetComponent<MySceneManager>().ChangeRoomScene("GameRoom");
    }
}
