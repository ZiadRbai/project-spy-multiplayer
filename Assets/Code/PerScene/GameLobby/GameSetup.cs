using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    [Space(10)]
    [SerializeField] RoleList roles;
    [SerializeField] PlayerList players;
    [SerializeField] WordList words;

    private string agentWord, spyWord, internWord;
    private List<Role> setRoles;
    private int ite;

    void Awake()
    {

        Room.IsOpenRoom(true);
    }

    public void StartGame()
    {
        Assignements();
        Room.IsOpenRoom(false);
        GetComponent<MySceneManager>().ChangeRoomScene("GameRoom");
    }

    private void Assignements()
    {
        //Room
        AssignNumberOfRounds();
        AssignWinningRole();
        AssignGameOver();
        AssignActivePlayers();

        AssignRolesWords(true, null);

        //Players
        foreach (KeyValuePair<int,BasePlayer> playerIn in players.roomList)
        {
            AssignRolesWords(false, playerIn.Value);
            AssignNonSpectators(playerIn.Value);
            AssignVotedOn(playerIn.Value);
            AssignIsOut(playerIn.Value);
            AssignHasWon(playerIn.Value);
        }
    }


    private void AssignRolesWords(bool partOne, BasePlayer player)
    {
        if (partOne)
        {
            ite = 0;
            this.setRoles = roles.GetRoleList((uint)players.GetRoomSize(), gameSettings.spyCount, gameSettings.internCount);

            this.agentWord = words.GetRandomWord();
            this.internWord = words.GetRandomWord();
            this.spyWord = null;
            while (this.internWord == this.agentWord)
            {
                this.internWord = words.GetRandomWord();
            }

            //Assigning the chosen agent word to the room, to be able to retrieve it later
            CustomProperties.SetRoomCustomProperty<string>(CustomProperties.Word, this.agentWord);
        }
        else
        {
            player.SetCustomProperty<int>(CustomProperties.Role, ((int)this.setRoles[ite].eRole));

            switch (this.setRoles[ite].eRole)
            {
                case eRole.Agent:
                    player.SetCustomProperty<string>(CustomProperties.Word, this.agentWord);
                    break;
                case eRole.Spy:
                    player.SetCustomProperty<string>(CustomProperties.Word, this.spyWord);
                    break;
                case eRole.Intern:
                    player.SetCustomProperty<string>(CustomProperties.Word, this.internWord);
                    break;
                default:
                    break;
            }
            ite++;
        }
    }

    private void AssignNonSpectators(BasePlayer player)
    {
        player.SetCustomProperty<bool>(CustomProperties.isOut, false);
    }

    private void AssignVotedOn(BasePlayer player)
    {
        player.SetCustomProperty<bool>(CustomProperties.isVotedOn, false);
    }

    private void AssignIsOut(BasePlayer player)
    {
        player.SetCustomProperty<bool>(CustomProperties.isOut, false);
    }

    private void AssignHasWon(BasePlayer player)
    {
        player.SetCustomProperty<bool>(CustomProperties.hasWon, false);
    }

    private void AssignWinningRole()
    {
        CustomProperties.SetRoomCustomProperty<int>(CustomProperties.WinningRole, (int)eRole.Spy);
    }

    private void AssignNumberOfRounds()
    {
        CustomProperties.SetRoomCustomProperty<int>(CustomProperties.CurrentRound, gameSettings.totalRounds);
    }
    private void AssignGameOver()
    {
        CustomProperties.SetRoomCustomProperty<bool>(CustomProperties.GameOver, false);
    }

    private void AssignActivePlayers()
    {
        CustomProperties.SetRoomCustomProperty<int>(CustomProperties.ActivePlayers, players.GetRoomSize());
    }
}
