using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityModelCollection", menuName = "WBTM/EntityModelCollection")]
public class EntityModelCollection : ScriptableObject
{
    [SerializeField]
    private List<VisualDescriptionModelSO> _headCollection = new();
    [SerializeField]
    private List<VisualDescriptionModelSO> _clothCollection = new();
    [SerializeField]
    private List<VerbalDescriptionModelSO> _dialogCollection = new();

    public List<VisualDescriptionModelSO> HeadCollection => _headCollection;
    public List<VisualDescriptionModelSO> ClothCollection => _clothCollection;
    public List<VerbalDescriptionModelSO> DialogCollection => _dialogCollection;
}
