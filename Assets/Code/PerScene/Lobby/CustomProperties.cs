using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CustomProperties : MonoBehaviour
{
    public const string Ready = "Ready";
    public const string Role = "Role";
    public const string Word = "Word";



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
        public static bool SwitchLocalReadyState()
        {
            bool newState;
            SetCustomProperty<bool>(Ready, PhotonNetwork.LocalPlayer, newState = !GetCustomProperty<bool>(Ready, PhotonNetwork.LocalPlayer));
            return newState;
        }

        public static void SetLocalPlayerProperties(string playerNickname)
        {
            SetlocalPlayerUsername(playerNickname);
            InitializeLocalCustomProperties();
        }

        private static void InitializeLocalCustomProperties()
        {
            SetCustomProperty<bool>(Ready, PhotonNetwork.LocalPlayer, false);
        }

        private static void SetlocalPlayerUsername(string textInputField)
        {
            if (!string.IsNullOrEmpty(textInputField))
            {
                PhotonNetwork.NickName = textInputField;
            }
            else
            {
                PhotonNetwork.NickName = "Guest#" + RandomStringGenerator(4, true);
            }
        }

        public static T GetLocalCustomProperty<T>(string property)
        {
            ExitGames.Client.Photon.Hashtable custProperties = PhotonNetwork.LocalPlayer.CustomProperties;
            if (custProperties.ContainsKey(property))
            {
                return (T)custProperties[property];
            }
            else
            {
                return default(T);
            }
        }

    }

    public static string RandomStringGenerator(int length, bool numbersOnly = false)
    {
        string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz1234567890";
        string generated_string = "";

        int range = 0;
        if (numbersOnly) { range = chars.Length - 10; } else { range = 0; }

        for (int i = 0; i < length; i++)
        {
            generated_string += chars[Random.Range(range, chars.Length)];
        }
        return generated_string;
    }
}
