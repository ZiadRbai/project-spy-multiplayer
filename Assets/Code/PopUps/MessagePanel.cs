using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{
    Transform panel;
    string message;
    string buttonText;


    public void OnEnable()
    {
        panel = transform.GetChild(0);
        panel.localScale = Vector3.zero;
        transform.GetChild(0).GetComponentInChildren<TMP_Text>().SetText(message);
        transform.GetChild(0).GetChild(1).GetComponentInChildren<TMP_Text>().SetText(buttonText);
        LeanTween.scale(panel.gameObject, Vector3.one, 0.1f);
    }

    public void OnClose()
    {
        LeanTween.scale(panel.gameObject, Vector3.zero, 0.1f).setOnComplete(DisableMe);
    }

    void DisableMe()
    {
        gameObject.SetActive(false);
    }

    public void DisplayMessage(string displayMessage, string _buttonText)
    {
        message = displayMessage;
        buttonText = _buttonText;
        gameObject.SetActive(true);
    }
}
