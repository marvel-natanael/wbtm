using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    [SerializeField]
    private HintModelSO _hintModelSO;

    private HintView _hintView => Ctx.Resolve<HintView>();
    public HintModelSO HintModelSO { get => _hintModelSO; set => _hintModelSO = value; }

    public void SetHintModel(List<EntityModelSO> badEntities)
    {
        if (badEntities == null) return;
        string description = string.Empty;
        _hintModelSO.Hints.Clear(); 
        foreach (var entity in badEntities)
        {
            description += "\n" + entity.HeadDescription.Description + " ";
            description += entity.ClothDescription.Description + " ";
            description += entity.VoiceDescription.Description;
            _hintModelSO.Hints.Add(description);
            description = string.Empty;
        }
        _hintView.HintModel = _hintModelSO;
    }

    public void ShowHint()
    {
        if (_hintModelSO != null)
        {
            _hintView.ShowHint();
        }
    }
}
