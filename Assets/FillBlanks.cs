using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class FillBlanks : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField roomInputField;

    [SerializeField]
    private StaticString LastRoom;

    void Start()
    {
        Debug.Log("RESTORED");
        RestoreName();
        RestoreRoom();
    }

    private void RestoreName()
    {
        nameInputField.text =  PhotonNetwork.LocalPlayer.NickName;
    }

    private void RestoreRoom()
    {
        roomInputField.text = LastRoom.value;
    }
}
