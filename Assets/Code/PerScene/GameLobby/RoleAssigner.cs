using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleAssigner : MonoBehaviour
{
    [SerializeField] RoleList roles;
    [SerializeField] PlayerList players;

    public uint spyCount;
    public uint internCount;


    public void AssignRoles()
    {
        List<Role> setRoles = roles.GetRoleList((uint)players.GetRoomSize(), spyCount, internCount);
        int i = 0;
        foreach (KeyValuePair<int,BasePlayer> playerIn in players.roomList)
        {
            playerIn.Value.SetCustomProperty<int>(CustomProperties.Role, ((int)setRoles[i].eRole));
            i++;
        }
    }

}
