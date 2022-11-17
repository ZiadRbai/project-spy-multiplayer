using UnityEngine;

public class StartGame :  MonoBehaviour, IButton
{
    [SerializeField] public GameSettings gameSettings;
    public PlayerList playerList;
    public PopUpManager popUpManager;
    public void OnClick()
    {
        if (playerList.GetRoomSize() < gameSettings.minPlayers)
        {
            popUpManager.DisplayPopUpMessage("You need at least "+ 
                gameSettings.minPlayers.ToString() +" players to start the game",
                "Close");
            return;
        }

        if (!playerList.isEveryoneReady())
        {
            popUpManager.DisplayPopUpMessage("Not all players are ready", "Close");
            return;
        }

        Starto();
    }

    private void Starto()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("PhotonView").gameObject;
        player1.GetComponent<GameSetup>().StartGame();
    }


}
