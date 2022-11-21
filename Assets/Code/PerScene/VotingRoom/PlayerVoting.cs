using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVoting : BasePlayerText
{
    [SerializeField] Button button;
    [SerializeField] Image image;
    [SerializeField] Color colorNormal;
    [SerializeField] Color colorHighlighted;
    [SerializeField] Color colorLocalPlayer;
    [SerializeField] Color colorIsOutPlayer;

    PlayerVoteManager pvm;
    private bool isMarkedOut = false;

    public override void SetPlayerInfo(Player player)
    {
        base.SetPlayerInfo(player);

        image.color = colorNormal;
        if (player.CustomProperties.ContainsKey(CustomProperties.isOut))
        {
            if ((bool)player.CustomProperties[CustomProperties.isOut] )
           {
                isMarkedOut = true;
                button.enabled = false;
                image.color = colorIsOutPlayer;
                return;
           }
        }

    }

    private void Awake()
    {
        pvm = transform.parent.GetComponent<PlayerVoteManager>();

        if (CustomProperties.LocalPlayer.GetLocalCustomProperty<bool>(CustomProperties.isOut))
        {
            isMarkedOut = true;
            button.enabled = false;
            image.color = colorIsOutPlayer;
        }
    }

    public void OnClick()
    {
        if (isMarkedOut || isLocalPlayer())  return;

        pvm.HighlightThis(this);
    }    

    public void ChangeHighlightTo(bool value )
    {
        if (isMarkedOut || isLocalPlayer())  return; 

        if (value)
        {
            image.color = colorHighlighted;
        }
        else
        {
            image.color = colorNormal;
        }
    }
}
