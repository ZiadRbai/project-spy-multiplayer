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

    private void Awake()
    {
        SetButtonText(CustomProperties.LocalPlayer.GetCustomProperty<bool>(CustomProperties.Ready));
    }
    public void OnClick()
    {
        SetButtonText(CustomProperties.LocalPlayer.SwitchLocalReadyState());
    }

    void SetButtonText(bool value)
    {
        if (value)
        {
            buttonText.SetText(textCancel);
        }
        else
        {
            buttonText.SetText(textReadyUp);
        }
    }

}
