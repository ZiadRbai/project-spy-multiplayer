using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class CardDisplay : MonoBehaviour
{
    [SerializeField]private RoleList roleList;

    [SerializeField] private TMP_Text roleText;
    [SerializeField] private TMP_Text wordText;
    [SerializeField] private TMP_Text yourWordIs;
    [SerializeField] private TMP_Text NoWord;

    [SerializeField] private TMP_Text descriptionText;


    private Role role;
    private string word;

    private void Awake()
    {
        switch (CustomProperties.LocalPlayer.GetLocalCustomProperty<int>(CustomProperties.Role))
        {
            case 0:
                role = roleList.agentRole;
                break;
            case 1:
                role = roleList.spyRole;
                break;
            case 2:
                role = roleList.internRole;
                break;
            default:
                break;
        }
        roleText.text = role.roleName;

        if (role.eRole == eRole.Spy)
        {
            yourWordIs.gameObject.SetActive(false);
            wordText.gameObject.SetActive(false);
            NoWord.gameObject.SetActive(true);
        }
        else
        {
            wordText.text = CustomProperties.LocalPlayer.GetLocalCustomProperty<string>(CustomProperties.Word);
        }
        
        descriptionText.text = role.roleDescription;
    }


}
