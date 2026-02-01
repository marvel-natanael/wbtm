using UnityEngine;

public class EndingView : MonoBehaviour
{
    [SerializeField]
    private GameObject _ending1;
    [SerializeField]
    private GameObject _ending2;
    [SerializeField]
    private GameObject _ending3;

    private void Awake()
    {
        _ending1.SetActive(false);
        _ending2.SetActive(false);
        _ending3.SetActive(false);
    }

    public void ShowEnding1()
    {
        _ending1.SetActive(true);
    }

    public void ShowEnding2()
    {
        _ending2.SetActive(true);
    }

    public void ShowEnding3()
    {
        _ending3.SetActive(true);
    }
}
