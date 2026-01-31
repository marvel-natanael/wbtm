using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI _headerText;
    [SerializeField]
    private TextMeshProUGUI _contentText;

    private void Awake()
    {
        HideDetails();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        HideDetails();
    }

    public void ShowDetails(HintModelSO detailsModelSO)
    {
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
