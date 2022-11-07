using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ErrorPanel : MonoBehaviour
{
    Transform panel;
    [HideInInspector] public string message;

    public void OnEnable()
    {
        panel = transform.GetChild(0);
        panel.localScale = Vector3.zero;
        transform.GetChild(0).GetComponentInChildren<TMP_Text>().SetText(message);
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

    public void DisplayError(string displayMessage)
    {
        GetComponent<ErrorPanel>().message = displayMessage;
        gameObject.SetActive(true);
    }


}
