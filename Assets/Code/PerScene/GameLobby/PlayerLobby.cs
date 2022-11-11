using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerLobby : BasePlayer
{ 
    [SerializeField] Toggle readyToggle;

    public override void SetPlayerInfo(Player player)
    {
        base.SetPlayerInfo(player);
        readyToggle.isOn = GetReadyStatus();
    }

    public bool GetReadyStatus()
    {
        return CustomProperties.GetCustomProperty<bool>(CustomProperties.Ready, _player);
    }
    public void SetReadyStatus(bool value)
    {
        CustomProperties.SetCustomProperty<bool>(CustomProperties.Ready, _player, value);
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
