using UnityEngine;

[CreateAssetMenu(menuName ="Scriptables/PopUp Manager")]
public class PopUpManager : ScriptableObject
{
    public GameObject MessagePopUpPrefab;

    public void DisplayPopUpMessage(string  Message, string buttonText)
    {
        if (MessagePopUpPrefab != null)
        {
            GameObject temp = Instantiate(MessagePopUpPrefab, GameObject.Find("Canvas").transform);
            temp.GetComponent<MessagePanel>().DisplayMessage(Message, buttonText);
        }
        else
        {
            Debug.LogError("MessagePopUp Prefab has not been assigned correctly");
        }
    }
}
