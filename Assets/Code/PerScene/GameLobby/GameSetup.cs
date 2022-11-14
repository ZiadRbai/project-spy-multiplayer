using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] RoleList roles;
    [SerializeField] PlayerList players;
    [SerializeField] WordList words;

    public uint spyCount;
    public uint internCount;


    public void AssignRolesAndWords()
    {
        List<Role> setRoles = roles.GetRoleList((uint)players.GetRoomSize(), spyCount, internCount);
        int i = 0;
        string agentWord = words.GetRandomWord();
        string internWord = words.GetRandomWord();
        string spyWord = null;

        foreach (KeyValuePair<int,BasePlayer> playerIn in players.roomList)
        {
            playerIn.Value.SetCustomProperty<int>(CustomProperties.Role, ((int)setRoles[i].eRole));

            switch (setRoles[i].eRole)
            {
                case eRole.Agent:
                    playerIn.Value.SetCustomProperty<string>(CustomProperties.Word, agentWord);
                    break;
                case eRole.Spy:
                    playerIn.Value.SetCustomProperty<string>(CustomProperties.Word, spyWord);
                    break;
                case eRole.Intern:
                    playerIn.Value.SetCustomProperty<string>(CustomProperties.Word, internWord);
                    break;
                default:
                    break;
            }
            i++;
        }
    }
    public void StartGame()
    {
        AssignRolesAndWords();


        GetComponent<MySceneManager>().ChangeRoomScene("GameRoom");
    }

}
