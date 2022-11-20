using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerLobby : BasePlayerText
{ 
    [SerializeField] Toggle readyToggle;

    public override void SetPlayerInfo(Player player)
    {
        base.SetPlayerInfo(player);
        readyToggle.isOn = GetCustomProperty<bool>(CustomProperties.Ready);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(targetPlayer!=null && targetPlayer == _player)
        {
            if (changedProps.ContainsKey(CustomProperties.Ready))
            {
                readyToggle.isOn = (bool)changedProps[CustomProperties.Ready];
            }
        }
    }

}
