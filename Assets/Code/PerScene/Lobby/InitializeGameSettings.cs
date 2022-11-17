using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGameSettings : MonoBehaviour
{


    [SerializeField]
    private GameSettings defaultSet, currentSet;

    void Awake()
    {
        currentSet.InitializeSettings(defaultSet);
    }

}
