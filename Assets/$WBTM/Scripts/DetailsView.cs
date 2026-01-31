using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetailsView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI _headerText;
    [SerializeField]
    private TextMeshProUGUI _contentText;

    public void OnPointerClick(PointerEventData eventData)
    {
        HideDetails();
    }

    public void ShowDetails(DetailsModelSO detailsModelSO)
    {
        _headerText.text = detailsModelSO.Type;
        _contentText.text = detailsModelSO.Description;
        gameObject.SetActive(true);
    }

    public void HideDetails()
    {
        _headerText.text = string.Empty;
        _contentText.text = string.Empty;
        gameObject.SetActive(false);
    }
}
