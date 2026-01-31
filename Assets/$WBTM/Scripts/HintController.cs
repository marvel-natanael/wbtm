using UnityEngine;

public class HintController : MonoBehaviour
{
    private HintView _detailView => Ctx.Resolve<HintView>();

    public void ShowHint(HintModelSO detailsModelSO)
    {
        if (detailsModelSO != null)
        {
            _detailView.ShowDetails(detailsModelSO);
        }
    }
}
