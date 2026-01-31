using UnityEngine;


[CreateAssetMenu(fileName = "EntityModelSO", menuName = "WBTM/EntityModelSO")]
public class EntityModelSO : ScriptableObject
{
    [SerializeField]
    private VisualDescriptionModelSO _headDescription;
    [SerializeField]
    private VisualDescriptionModelSO _clothDescription;
    [SerializeField]
    private VerbalDescriptionModelSO _voiceDescription;

    public VisualDescriptionModelSO HeadDescription => _headDescription;
    public VisualDescriptionModelSO ClothDescription => _clothDescription;
    public VerbalDescriptionModelSO VoiceDescription => _voiceDescription;

    public bool IsBad;
}