using UnityEngine;

public class InitializeScriptableVariables : MonoBehaviour
{
    [SerializeField]
    private StaticString RoomName;

    public void Reset()
    {
        RoomName.value = null;
    }
}
