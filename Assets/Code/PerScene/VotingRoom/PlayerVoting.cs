using UnityEngine;
using UnityEngine.UI;

public class PlayerVoting : BasePlayer
{
    [SerializeField] Button button;
    [SerializeField] Image image;
    [SerializeField] Color colorNormal;
    [SerializeField] Color colorHighlighted;
    [SerializeField] Color colorLocalPlayer;

    public int VotesOn = 0;

    PlayerVoteManager pvm;

    private void Awake()
    {
        pvm = transform.parent.GetComponent<PlayerVoteManager>();
        image.color = colorNormal;
    }

    public void OnClick()
    {
        pvm.HighlightThis(this);
    }    

    public void ChangeHighlightTo(bool value )
    {
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
