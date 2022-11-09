using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame :  MonoBehaviour
{
    
    public void OnClick()
    {
        if (CheckRoomReady())
        {
            ChangeRooms();
        }
        else
        {
            GameObject.Find("Canvas/PopUpManager").GetComponent<PopUps>().DisplayPopUpMessage("Not all players are ready", "Close");
        }
    }

    private bool CheckRoomReady()
    {
        return GameObject.Find("Canvas/PlayerList").GetComponent<PlayerList>().isEveryoneReady();
    }

    private void ChangeRooms()
    {
        GameObject.FindGameObjectWithTag("PhotonView").GetComponent<MySceneManager>().ChangeRoomScene("GameRoom");
    }


}
