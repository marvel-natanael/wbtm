using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _headerText;
    [SerializeField]
    private TextMeshProUGUI _contentText;
    [SerializeField]
    private string _header;
    private HintModelSO _hintModel;

    private int _selectedIndex = 0;

    public static bool Active;
    public HintModelSO HintModel { get => _hintModel; set { _hintModel = value; _selectedIndex = 0; } }


    private void Awake()
    {
        HideHint();
    }
    public void NextHint()
    {
        _selectedIndex++;
        ScrollHint();
    }

    public void PreviousHint()
    {
        _selectedIndex--;
        ScrollHint();

    }

    public void ScrollHint()
    {
        if (_selectedIndex < 0 || _selectedIndex >= _hintModel.Hints.Count)
        {
            HideHint();
        }
        else
        {
            ShowHint();
        }
    }

    public void ShowHint()
    {
        _headerText.text = _header + " #" + (_selectedIndex + 1).ToString();
        _contentText.text = _hintModel.Hints[_selectedIndex];
        gameObject.SetActive(true);
        Active = true;
    }

    public void HideHint()
    {
        _selectedIndex = 0;
        _contentText.text = string.Empty;
        gameObject.SetActive(false);
        Active = false;
    }
}
