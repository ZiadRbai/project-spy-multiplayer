using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class PlayerElement : MonoBehaviour
{
    [SerializeField] private TMP_Text textAsset;
    private Player _player;

    public Player player { get; private set;}

    public void SetPlayerInfo(Player player)
    {

        _player = player;
        textAsset.SetText(player.NickName);
    }
    
}
