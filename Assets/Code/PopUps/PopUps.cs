using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUps : MonoBehaviour
{
    GameObject MessagePopUp;

    private void Start()
    {
        MessagePopUp = Resources.Load<GameObject>("Prefabs/PopUps/MessagePopUp");
    }

    public void DisplayPopUpMessage(string Message, string buttonText)
    {
        if (MessagePopUp != null)
        {
            GameObject temp = Instantiate(MessagePopUp, this.transform);
            temp.GetComponent<MessagePanel>().DisplayMessage(Message, buttonText);
        }
        else
        {
            Debug.LogError("MessagePopUp Prefab has not been assigned correctly");
        }
    }
}
