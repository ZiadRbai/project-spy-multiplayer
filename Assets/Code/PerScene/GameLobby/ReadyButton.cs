using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ReadyButton : MonoBehaviour, IButton
{
    [SerializeField] TMP_Text buttonText;
    const string  textReadyUp = "Ready Up";
    const string  textCancel  = "Cancel";
    public void OnClick()
    {
        if (CustomProperties.LocalPlayer.SwitchLocalReadyState())
        {
            buttonText.SetText(textCancel);
        }
        else
        {
            buttonText.SetText(textReadyUp);
        }
    }
}
