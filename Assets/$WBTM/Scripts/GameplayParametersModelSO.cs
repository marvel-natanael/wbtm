using UnityEngine;

[CreateAssetMenu(fileName = "GameplayParametersModelSO", menuName = "WBTM/GameplayParametersModelSO")]
public class GameplayParametersModelSO : ScriptableObject
{
    [SerializeField]
    private int _badEntitiesToLose = 3;

    public int BadEntitiesToLose => _badEntitiesToLose;
}
