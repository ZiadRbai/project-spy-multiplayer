using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class BasePlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] protected TMP_Text textAsset;
    protected Player _player;

    protected Player player { get; set; }

    public virtual void SetPlayerInfo(Player player)
    {
        _player = player;
        textAsset.SetText(player.NickName);
    }
    public void SetCustomProperty<T>(string property, T value)
    {
        CustomProperties.SetCustomProperty<T>(property, _player, value);
    }
    public T GetCustomProperty<T>(string property)
    {
        return CustomProperties.GetCustomProperty<T>(property, _player);
    }
}
