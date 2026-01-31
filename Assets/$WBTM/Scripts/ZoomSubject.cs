using UnityEngine;
using Unity.Cinemachine;

public class ZoomSubject : MonoBehaviour
{
    [SerializeField]
    private Vector3 _zoomInOffset;

    private ZoomController _zoomController => Ctx.Resolve<ZoomController>();

    private void OnMouseDown()
    {
        _zoomController.ZoomIn(transform, _zoomInOffset);
    }

    private void OnMouseUp()
    {
        _zoomController.ZoomOut();
    }
}
