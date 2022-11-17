using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerVoting : BasePlayer
{
    [SerializeField] Button button;
    [SerializeField] Image image;
    [SerializeField] Color colorNormal;
    [SerializeField] Color colorHighlighted;

    bool isHighlighted = false;
    PlayerVoteManager pvm;

    private void Awake()
    {
        pvm = transform.parent.GetComponent<PlayerVoteManager>();   
    }

    public void OnClick()
    {
        pvm.HighlightThis(this);
    }    

    public void SwitchHighlight(bool value)
    {
        if (value)
        {
            isHighlighted = true;
            image.color = colorHighlighted;
        }
        else
        {
            isHighlighted = true;
            image.color = colorNormal;
        }
    }

}
