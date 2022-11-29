using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class GuessButton : MonoBehaviour, IButton
{
    [SerializeField] private TMP_InputField textToSend;
    [SerializeField] private MySceneManager msm;
    [SerializeField] private Button button;
    private string word;

    private void Awake()
    {
        if (CustomProperties.LocalPlayer.GetCustomProperty<int>(CustomProperties.Role) == (int)eRole.Spy)
        {
            textToSend.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            word = CustomProperties.GetRoomCustomProperty<string>(CustomProperties.Word);
        }
    }
    public void OnClick()
    {
        if (textToSend.text.Equals(word))
        {
            CustomProperties.SetRoomCustomProperty<int>(CustomProperties.WinningRole, (int)eRole.Spy);
            CustomProperties.SetRoomCustomProperty<bool>(CustomProperties.GameOver, true);
            msm.SpyWin("ResultsRoom");
        }
        else
        {
            textToSend.text = "";
        }
    }
}
