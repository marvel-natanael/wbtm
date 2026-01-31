using UnityEngine;

[CreateAssetMenu(fileName = "VerbalDescriptionModelSO", menuName = "WBTM/VerbalDescriptionModelSO")]
public class VerbalDescriptionModelSO : DescriptionModelSO
{
    [SerializeField]
    private string _verbalContent;

    public string VerbalContent => _verbalContent;
}