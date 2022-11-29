using UnityEngine;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class BasePlayerText : BasePlayer
{
    [SerializeField] protected TMP_Text textAsset;
    [SerializeField] protected Image image;


    public override void SetPlayerInfo(Player player)
    {
        base.SetPlayerInfo(player);

        textAsset.SetText(player.NickName);
        if(CustomProperties.GetCustomProperty<bool>(CustomProperties.isOut, player))
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
        }
    }

}
