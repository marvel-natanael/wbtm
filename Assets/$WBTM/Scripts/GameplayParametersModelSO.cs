using UnityEngine;

[CreateAssetMenu(fileName = "GameplayParametersModelSO", menuName = "WBTM/GameplayParametersModelSO")]
public class GameplayParametersModelSO : ScriptableObject
{
    [SerializeField]
    private int _badEntitiesToLose = 3;
    [SerializeField]
    private int _entitiesPerLevel = 10;

    public int BadEntitiesToLose => _badEntitiesToLose;
    public int EntitiesPerLevel => _entitiesPerLevel;
}
