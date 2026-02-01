using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HintModelSO", menuName = "WBTM/HintModelSO")]
public class HintModelSO : ScriptableObject
{
    private List<string> _description = new();

    public List<string> Hints { get => _description; set => _description = value; }
}
