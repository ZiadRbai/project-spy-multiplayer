using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Roles/Role")]
public class Role : ScriptableObject
{
    
    [SerializeField]
    public eRole eRole;

    public string roleName;

    [TextArea(15, 20)]
    public string roleDescription;
}

public enum eRole { Agent, Spy, Intern }

