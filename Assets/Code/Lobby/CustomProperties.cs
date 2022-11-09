using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CustomProperties : MonoBehaviour
{
    public const string Ready = "Ready";

    public static T GetCustomProperty<T>(string property, Player targetPlayer)
    {
        ExitGames.Client.Photon.Hashtable custProperties = targetPlayer.CustomProperties;
        if (custProperties.ContainsKey(property))
        {
            return (T)custProperties[property];
        }
        else
        {
            return default(T);
        }
    }

    public static void SetCustomProperty<T>(string property, Player targetPlayer, T value)
    {
        ExitGames.Client.Photon.Hashtable custProperties = targetPlayer.CustomProperties;
        custProperties[property] = value;
        targetPlayer.SetCustomProperties(custProperties);
    }

    public class LocalPlayer
    {
        public static void InitializeLocalCustomProperties()
        {
            SetCustomProperty<bool>(Ready, PhotonNetwork.LocalPlayer, false);
        }

        public static bool SwitchLocalReadyState()
        {
            bool newState;
            SetCustomProperty<bool>(Ready, PhotonNetwork.LocalPlayer, newState = !GetCustomProperty<bool>(Ready, PhotonNetwork.LocalPlayer));
            Debug.Log("newState =" + newState);
            return newState;
        }

    }

}
