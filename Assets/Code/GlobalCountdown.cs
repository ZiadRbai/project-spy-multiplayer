using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class GlobalCountdown : MonoBehaviourPunCallbacks
{
    public delegate void Countdown();
    public static event Countdown OnCountdownEnd;

    [SerializeField] GameSettings gameSettings;
    [SerializeField] bool isRound_notVote;
    [SerializeField] int timerOverride = -1;
    [Space(10)]
    [SerializeField] TMP_Text timerText;


    private int timerInSeconds;
    bool started = false;
    double initTime;
    int timerValue;

    void Start()
    {
        if (isRound_notVote)
            timerInSeconds = gameSettings.secondsPerRound;
        else
            timerInSeconds = gameSettings.secondsPerVotingRound;

        if (timerOverride != -1)
            timerInSeconds = timerOverride;

        timerText.text = timeFormat(timerInSeconds);
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Invoke("MasterStartTimer", 1f);
        }
        PhotonNetwork.AddCallbackTarget(this);
    }

    void Update()
    {
        if (!started) return;

        timerValue = timerInSeconds - (int)(PhotonNetwork.Time - initTime);
        if (timerValue <= 0)
        {
            if(OnCountdownEnd != null) 
                OnCountdownEnd();

            started = false;
        }

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
