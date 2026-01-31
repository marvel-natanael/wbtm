using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class ZoomController : MonoBehaviour
{
    [SerializeField]
    private Transform originalTarget;
    [SerializeField]
    private Vector3 originalOffset;
    [SerializeField]
    private CinemachineCamera virtualCamera;
    [SerializeField]
    private float zoomedDistance = 5f;
    [SerializeField]
    private float zoomDuration = 0.5f;
    [SerializeField] private float rotationSpeed = 3f;

    private float originalDistance;
    private bool isZoomed = false;
    private CinemachinePositionComposer framingTransposer;
    private float originalScreenX;
    private float originalScreenY;
    private Vector2 originalScreenPos;

    private void Start()
    {
        if (virtualCamera != null)
        {
            framingTransposer = virtualCamera.GetComponent<CinemachinePositionComposer>();
            if (framingTransposer != null)
            {
                originalDistance = framingTransposer.CameraDistance;
                originalScreenX = framingTransposer.Composition.ScreenPosition.x;
                originalScreenY = framingTransposer.Composition.ScreenPosition.y;
                originalScreenPos = framingTransposer.Composition.ScreenPosition;
                originalTarget = framingTransposer.FollowTarget;
                originalOffset = framingTransposer.TargetOffset;
            }
        }
    }

    private void Update()
    {
        if (isZoomed && framingTransposer != null)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            framingTransposer.Composition.ScreenPosition.x += mouseX;
            framingTransposer.Composition.ScreenPosition.y -= mouseY;
        }
    }

    public void ZoomIn(Transform target, Vector3 offset)
    {
        if (framingTransposer == null || isZoomed) return;
        virtualCamera.Target.TrackingTarget = target;
        framingTransposer.TargetOffset = offset;
        StartCoroutine(ScaleDistanceTo(zoomedDistance, zoomDuration, false));
        isZoomed = true;
    }

    public void ZoomOut()
    {
        if (framingTransposer == null || !isZoomed) return;
        virtualCamera.Target.TrackingTarget = originalTarget;
        framingTransposer.TargetOffset = originalOffset;
        StartCoroutine(ScaleDistanceTo(originalDistance, zoomDuration, true));
        isZoomed = false;
    }

    private IEnumerator ScaleDistanceTo(float targetDistance, float duration, bool resetPosition)
    {
        float startDistance = framingTransposer.CameraDistance;
        float startX = framingTransposer.Composition.ScreenPosition.x;
        float startY = framingTransposer.Composition.ScreenPosition.y;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            framingTransposer.CameraDistance = Mathf.Lerp(startDistance, targetDistance, t);
            framingTransposer.Composition.ScreenPosition.x = Mathf.Lerp(startX, originalScreenX, t);
            framingTransposer.Composition.ScreenPosition.y = Mathf.Lerp(startY, originalScreenY, t);
            yield return null;
        }

        framingTransposer.CameraDistance = targetDistance;
        if (resetPosition)
        {
            framingTransposer.Composition.ScreenPosition = originalScreenPos;
        }
    }
}
