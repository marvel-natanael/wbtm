using UnityEngine; 

[CreateAssetMenu(fileName = "HintModelSO", menuName = "WBTM/HintModelSO")]
public class HintModelSO : ScriptableObject
{ 
    [SerializeField]
    [TextArea]
    private string _description;
     
    public string Description => _description;
}
