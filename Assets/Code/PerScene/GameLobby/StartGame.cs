
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
        GameObject player1 = GameObject.FindGameObjectWithTag("PhotonView").gameObject;
        player1.GetComponent<RoleAssigner>().AssignRoles();
        player1.GetComponent<MySceneManager>().ChangeRoomScene("GameRoom");
    }


}
