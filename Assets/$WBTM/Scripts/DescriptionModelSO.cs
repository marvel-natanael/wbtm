using System.Collections.Generic;
using UnityEngine;

public enum DescriptionType
{
    MASK,
    CLOTH,
    VOICE
}

[CreateAssetMenu(fileName = "DescriptionModelSO", menuName = "WBTM/DescriptionModelSO")]
public class DescriptionModelSO : ScriptableObject
{
    [SerializeField]
    private List<string> _descriptions = new List<string>();
    [SerializeField]
    private DescriptionType _descriptionType;

    public string Description => _descriptions[Random.Range(0, _descriptions.Count)];
    public DescriptionType DescriptionType => _descriptionType;
}
