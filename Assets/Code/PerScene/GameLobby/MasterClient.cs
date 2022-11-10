using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MasterClient : MonoBehaviourPunCallbacks
{
    [HideInInspector] public bool isMaster = false;

    [SerializeField]
    private GameObject startGameButton;
    
    void Awake()
    {
        SetMasterStatus();
    }

    void SetMasterStatus()
    {
        isMaster = PhotonNetwork.IsMasterClient;
        SetUI();

    }

    void SetUI()
    {
        if (isMaster)
        {
            startGameButton.SetActive(true);
        }
    }


    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        SetMasterStatus();
    }

    
}
