using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class PlayerElement : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text textAsset;
    [SerializeField] Toggle readyToggle;
     Player _player;
    
    public Player player { get; private set;}

    public void SetPlayerInfo(Player player)
    {
        _player = player;
        textAsset.SetText(player.NickName);
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
