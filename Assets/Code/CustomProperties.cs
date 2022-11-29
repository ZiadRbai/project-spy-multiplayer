using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CustomProperties 
{
    //Player properties
    public const string Ready = "Ready";
    public const string Role = "Role"; //int
    public const string Word = "Word"; //string
    public const string Vote = "Vote"; //int
    public const string isVotedOn = "isVotedOn"; //bool
    public const string isOut = "isOut"; //bool
    public const string hasWon = "hasWon"; //bool
    
    //Room Properties
    public const string CurrentRound = "CurrentRound"; //int
    public const string WinningRole = "WinningRole"; //int
    public const string GameOver = "GameOver"; //bool
    public const string ActivePlayers = "ActivePlayers"; //int


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

    public static void SetRoomCustomProperty<T>(string property, T value)
    {
        ExitGames.Client.Photon.Hashtable custProperties = PhotonNetwork.CurrentRoom.CustomProperties;
        custProperties[property] = value;
        PhotonNetwork.CurrentRoom.SetCustomProperties(custProperties);
    }

    public static T GetRoomCustomProperty<T>(string property)
    {
        ExitGames.Client.Photon.Hashtable custProperties = PhotonNetwork.CurrentRoom.CustomProperties;
        if (custProperties.ContainsKey(property))
        {
            return (T)custProperties[property];
        }
        else
        {
            return default(T);
        }
    }

    public class CurrentRoom
    {
        public static void IncrementCustomProperty(string property, int value)
        {
            ExitGames.Client.Photon.Hashtable custProperties = PhotonNetwork.CurrentRoom.CustomProperties;
            custProperties[property] = (int)custProperties[property] + value;
            PhotonNetwork.CurrentRoom.SetCustomProperties(custProperties);
        }
    }

    public class LocalPlayer
    {
        public static bool SwitchLocalReadyState()
        {
            bool newState;
            CustomProperties.SetCustomProperty(Ready, PhotonNetwork.LocalPlayer, newState = !CustomProperties.GetCustomProperty<bool>(Ready, PhotonNetwork.LocalPlayer));
            return newState;
        }

        public static void SetPlayerReady(string playerNickname)
        {
            SetPlayerUsername(playerNickname);
            CustomProperties.SetCustomProperty(Ready, PhotonNetwork.LocalPlayer, false);
        }

        private static void SetPlayerUsername(string textInputField)
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

        public static T GetCustomProperty<T>(string property)
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

        public static void SetCustomProperty<T>(string property, T value)
        {
            ExitGames.Client.Photon.Hashtable custProperties = PhotonNetwork.LocalPlayer.CustomProperties;
            custProperties[property] = value;
            PhotonNetwork.LocalPlayer.SetCustomProperties(custProperties);
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
