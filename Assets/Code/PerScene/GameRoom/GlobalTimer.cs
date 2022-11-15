using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class GlobalTimer : MonoBehaviourPunCallbacks
{
    [SerializeField] int timerInSeconds;
    [SerializeField] TMP_Text timerText;
    bool started = false;
    double initTime;
    int timerValue;


    void Start()
    {
        timerText.text = timeFormat(timerInSeconds);
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Invoke("MasterStartTimer", 2f);
        }
        PhotonNetwork.AddCallbackTarget(this);
    }

    void Update()
    {
        if (!started) return;

        timerValue = timerInSeconds - (int)(PhotonNetwork.Time - initTime);
        timerText.text = timeFormat(timerValue);
    }

    private string timeFormat(int inSeconds)
    {
        string minutes = Mathf.Floor(inSeconds / 60).ToString("00");
        string seconds = (inSeconds % 60).ToString("00");

        return string.Format("{0}:{1}", minutes, seconds);
    }

    public void MasterStartTimer()
    {
        initTime = PhotonNetwork.Time;
        CustomProperties.SetRoomCustomProperty<double>("StartTime", initTime);
        started = true;
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        if (propertiesThatChanged.ContainsKey("StartTime"))
        {
            initTime = (double)propertiesThatChanged["StartTime"];
            started = true;
        }
    }
}
