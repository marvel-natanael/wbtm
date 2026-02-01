using TMPro;
using UnityEngine;

public class VisitorCountView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _visitorCountText;
    [SerializeField]
    private string _visitorCountLabel = "Visitor";

    public void UpdateText(int visitorCount, int maxVisitor)
    {
        _visitorCountText.text = $"{_visitorCountLabel}\n{(visitorCount + 1)}/{maxVisitor}";
    }
}
