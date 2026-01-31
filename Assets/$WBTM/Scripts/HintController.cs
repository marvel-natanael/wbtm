using UnityEngine;

public class HintController : MonoBehaviour
{
    private DetailsView _detailView => Ctx.Resolve<DetailsView>();

    public void ShowHint(DetailsModelSO detailsModelSO)
    {
        if (detailsModelSO != null)
        {
            _detailView.ShowDetails(detailsModelSO);
        }
    }
}
