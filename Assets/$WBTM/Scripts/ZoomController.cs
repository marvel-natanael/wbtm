using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class ZoomController : MonoBehaviour
{
    [SerializeField]
    private Transform _originalTarget;
    [SerializeField]
    private Vector3 _originalOffset;
    [SerializeField]
    private CinemachineCamera _virtualCamera;
    [SerializeField]
    private float _zoomedDistance = 5f;
    [SerializeField]
    private float _zoomDuration = 0.5f;
    [SerializeField]
    private float _rotationSpeed = 3f;

    private float _originalDistance;
    private bool _isZoomed = false;
    private CinemachinePositionComposer _framingTransposer;
    private float _originalScreenX;
    private float _originalScreenY;
    private Vector2 _originalScreenPos;

    private CinemachinePositionComposer FramingTransposer {
        get {
            if (_framingTransposer == null && _virtualCamera != null)
                _framingTransposer = _virtualCamera.GetComponent<CinemachinePositionComposer>();
            return _framingTransposer;
        }
    }

    private void Start()
    {
        if (_virtualCamera != null)
        {
            if (FramingTransposer != null)
            {
                _originalDistance = FramingTransposer.CameraDistance;
                _originalScreenX = FramingTransposer.Composition.ScreenPosition.x;
                _originalScreenY = FramingTransposer.Composition.ScreenPosition.y;
                _originalScreenPos = FramingTransposer.Composition.ScreenPosition;
                _originalTarget = FramingTransposer.FollowTarget;
                _originalOffset = FramingTransposer.TargetOffset;
            }
        }
    }

    private void Update()
    {
        if (_isZoomed && FramingTransposer != null)
        {
            float mouseX = Input.GetAxis("Mouse X") * _rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * _rotationSpeed;
            FramingTransposer.Composition.ScreenPosition.x += mouseX;
            FramingTransposer.Composition.ScreenPosition.y -= mouseY;
        }
    }

    public void ZoomIn(Transform target, Vector3 offset)
    {
        if (FramingTransposer == null || _virtualCamera == null || _isZoomed) return;
        _virtualCamera.Target.TrackingTarget = target;
        FramingTransposer.TargetOffset = offset;
        StartCoroutine(ScaleDistanceTo(_zoomedDistance, _zoomDuration, false));
        _isZoomed = true;
    }

    public void ZoomOut()
    {
        if (FramingTransposer == null || _virtualCamera == null || _isZoomed) return;
        _virtualCamera.Target.TrackingTarget = _originalTarget;
        FramingTransposer.TargetOffset = _originalOffset;
        StartCoroutine(ScaleDistanceTo(_originalDistance, _zoomDuration, true));
        _isZoomed = false;
    }

    private IEnumerator ScaleDistanceTo(float targetDistance, float duration, bool resetPosition)
    {
        float startDistance = FramingTransposer.CameraDistance;
        float startX = FramingTransposer.Composition.ScreenPosition.x;
        float startY = FramingTransposer.Composition.ScreenPosition.y;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            FramingTransposer.CameraDistance = Mathf.Lerp(startDistance, targetDistance, t);
            FramingTransposer.Composition.ScreenPosition.x = Mathf.Lerp(startX, _originalScreenX, t);
            FramingTransposer.Composition.ScreenPosition.y = Mathf.Lerp(startY, _originalScreenY, t);
            yield return null;
        }

        FramingTransposer.CameraDistance = targetDistance;
        if (resetPosition)
        {
            FramingTransposer.Composition.ScreenPosition = _originalScreenPos;
        }
    }
}
