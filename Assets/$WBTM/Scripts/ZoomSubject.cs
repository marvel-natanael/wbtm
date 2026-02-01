using UnityEngine;
using Unity.Cinemachine;

public class ZoomSubject : MonoBehaviour
{
    [SerializeField]
    private Vector3 _zoomInOffset;

    private ZoomController _zoomController => Ctx.Resolve<ZoomController>();

    private void OnMouseDown()
    {
        if (HintView.Active) return;
        _zoomController.ZoomIn(transform, _zoomInOffset);
    }

    private void OnMouseUp()
    {
        if (HintView.Active) return;
        _zoomController.ZoomOut();
    }
}
