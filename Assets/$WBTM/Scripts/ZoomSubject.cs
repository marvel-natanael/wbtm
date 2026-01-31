using UnityEngine; 
using Unity.Cinemachine;

public class ZoomSubject : MonoBehaviour
{
    private ZoomController _zoomController => Ctx.Resolve<ZoomController>();

    private void OnMouseDown()
    {
        _zoomController.ZoomIn(transform);
    }

    private void OnMouseUp()
    {
        _zoomController.ZoomOut();
    } 
}
