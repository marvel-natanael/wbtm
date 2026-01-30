using TMPro;
using UnityEngine;

public class DetailsView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _headerText;
    [SerializeField]
    private TextMeshProUGUI _contentText;

    public void ShowDetails(DetailsModelSO detailsModelSO)
    {
        _headerText.text = detailsModelSO.Type;
        _contentText.text = detailsModelSO.Description;
        gameObject.SetActive(true);
    }
}
