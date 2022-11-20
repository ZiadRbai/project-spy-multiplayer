using UnityEngine;
using Photon.Realtime;
using TMPro;

public class BasePlayerText : BasePlayer
{
    [SerializeField] protected TMP_Text textAsset;

    public override void SetPlayerInfo(Player player)
    {
        base.SetPlayerInfo(player);

        textAsset.SetText(player.NickName);
    }

}
