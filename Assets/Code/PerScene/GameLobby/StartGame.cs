using UnityEngine;

public class StartGame :  MonoBehaviour, IButton
{
    public PlayerList playerList;
    public PopUpManager popUpManager;
    public void OnClick()
    {
        if (playerList.isEveryoneReady())
        {
            Starto();
        }
        else
        {
            popUpManager.DisplayPopUpMessage("Not all players are ready", "Close");
        }
    }

    private void Starto()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("PhotonView").gameObject;
        player1.GetComponent<GameSetup>().StartGame();
    }


}
