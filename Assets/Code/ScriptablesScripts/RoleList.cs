using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime;

[CreateAssetMenu(menuName = "Scriptables/Roles/Role List")]

public class RoleList : ScriptableObject
{
    [SerializeField] public Role agentRole;
    [SerializeField] public Role spyRole;
    [SerializeField] public Role internRole;


    public List<Role> GetRoleList(uint playerCount, uint spyCount, uint internCount)
    {
        List<Role> playerRoles = new List<Role>();

        for (uint i = 0; i < spyCount; i++)
        {
            playerRoles.Add(spyRole);
        }
        for (uint i = 0; i < internCount; i++)
        {
            playerRoles.Add(internRole);
        }
        for (uint i = 0; i < playerCount - internCount - spyCount; i++)
        {
            playerRoles.Add(agentRole);
        }


        return ShuffleRoles(playerRoles);
    }

    public List<Role> ShuffleRoles(List<Role> baseList)
    {
        for (int i = 0; i < baseList.Count; i++)
        {
            Role temp = baseList[i];
            int randomIndex = Random.Range(i, baseList.Count);
            baseList[i] = baseList[randomIndex];
            baseList[randomIndex] = temp;
        }
        return baseList;
    }
}
