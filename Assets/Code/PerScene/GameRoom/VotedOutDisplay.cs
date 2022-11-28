using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VotedOutDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text votedOutText;

    void Start()
    {
        if (CustomProperties.LocalPlayer.GetCustomProperty<bool>(CustomProperties.isOut))
        {
            votedOutText.enabled = true;
        }
    }

    
}
