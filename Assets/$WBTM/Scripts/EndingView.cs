using UnityEngine;

public class EndingView : MonoBehaviour
{
    [SerializeField]
    private GameObject _winText;
    [SerializeField]
    private GameObject _loseText;

    public static bool IsWin;

    private void OnEnable()
    {
        ManageEndingView();
    }

    public void ManageEndingView()
    {
        _winText.SetActive(IsWin);
        _loseText.SetActive(!IsWin);
    }
}
