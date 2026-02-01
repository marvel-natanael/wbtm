using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    private HintModelSO _hintModelSO;

    private HintView _hintView => Ctx.Resolve<HintView>();
    public HintModelSO HintModelSO { get => _hintModelSO; set => _hintModelSO = value; }

    public void SetHintModel(List<EntityModelSO> badEntities)
    {
        if (_hintModelSO == null)
        {
            _hintModelSO = ScriptableObject.CreateInstance<HintModelSO>();
        }

        string description = string.Empty;
        foreach (var entity in badEntities)
        {
            description += "\n" + entity.HeadDescription.Description + "\n\n";
            description += entity.ClothDescription.Description + "\n\n";
            description += entity.VoiceDescription.Description + "\n\n";
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
