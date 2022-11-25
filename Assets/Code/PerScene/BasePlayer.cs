using Photon.Realtime;
using UnityEngine;
using Photon.Pun;

public class BasePlayer : MonoBehaviourPunCallbacks
{
    protected Player _player;

    protected Player player { get; set; }

    public virtual void SetPlayerInfo(Player player)
    {
        _player = player;
    }

    public bool isLocalPlayer()
    {
        return _player.IsLocal;
    }

    public void SetCustomProperty<T>(string property, T value)
    {
        CustomProperties.SetCustomProperty<T>(property, _player, value);
    }
    public T GetCustomProperty<T>(string property)
    {
        return CustomProperties.GetCustomProperty<T>(property, _player);
    }

    public Player GetPlayerObject()
    {
        return _player;
    }


}