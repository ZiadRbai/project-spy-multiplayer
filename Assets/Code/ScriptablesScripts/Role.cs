using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Role")]
public class Role : ScriptableObject
{
    public int roleId;
    public string roleName;

    [TextArea(15, 20)]
    public string roleDescription;
}
