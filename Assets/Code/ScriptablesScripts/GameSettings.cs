using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Rounds")]
    public int secondsPerVotingRound;
    public int secondsPerRound;
    public int totalRounds;

    [HideInInspector]
    public int currentRound;

    [Space(10)]
    [Header("Players")]
    public byte minPlayers;
    public byte maxPlayers;

    [Space(10)]
    [Header("Roles")]
    public uint spyCount;
    public uint internCount;

    public void InitializeSettings(GameSettings defaultGS)
    {
        this.secondsPerRound = defaultGS.secondsPerRound;
        this.totalRounds = defaultGS.totalRounds;
        this.secondsPerVotingRound = defaultGS.secondsPerVotingRound;

        this.minPlayers = defaultGS.minPlayers;
        this.maxPlayers = defaultGS.maxPlayers;

        this.spyCount = defaultGS.spyCount;
        this.internCount = defaultGS.internCount;
    }
}
