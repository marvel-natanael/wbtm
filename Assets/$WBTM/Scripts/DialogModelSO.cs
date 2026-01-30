using UnityEngine;

[CreateAssetMenu(fileName = "DialogModelSO", menuName = "WBTM/DialogModelSO")]
public class DialogModelSO : ScriptableObject
{
    [SerializeField]
    [TextArea]
    private string _message;

    public string Message
    {
        get
        {
            return _message; 
        }
        set
        {
            _message = value;
        }
    }
}
