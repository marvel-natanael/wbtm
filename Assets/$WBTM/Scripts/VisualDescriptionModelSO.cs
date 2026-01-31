using UnityEngine;

[CreateAssetMenu(fileName = "VisualDescriptionModelSO", menuName = "WBTM/VisualDescriptionModelSO")]
public class VisualDescriptionModelSO : DescriptionModelSO
{
    [SerializeField]
    private Sprite _visualContent;

    public Sprite VisualContent => _visualContent;
}