using UnityEngine;

public enum DetailType
{
    HEAD,
    CLOTHES,
    VOICE,
    HINT
}

[CreateAssetMenu(fileName = "DetailsModelSO", menuName = "WBTM/DetailsModelSO")]
public class DetailsModelSO : ScriptableObject
{
    [SerializeField]
    private DetailType _type;
    [SerializeField]
    [TextArea]
    private string _description;

    public string Type => _type.ToString();
    public string Description => _description;
}
