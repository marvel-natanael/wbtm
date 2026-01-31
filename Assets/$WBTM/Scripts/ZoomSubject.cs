using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class ZoomSubject : MonoBehaviour
{
    [SerializeField] private CinemachineCamera virtualCamera;
    [SerializeField] private float zoomedDistance = 5f;
    [SerializeField] private float zoomDuration = 0.5f;
    [SerializeField] private float rotationSpeed = 3f;

    private float originalDistance;
    private bool isZoomed = false;
    private CinemachinePositionComposer framingTransposer;

    private void Start()
    {
        if (virtualCamera != null)
        {
            framingTransposer = virtualCamera.GetComponent<CinemachinePositionComposer>();
            if (framingTransposer != null)
            {
                originalDistance = framingTransposer.CameraDistance;
            }
        }
    }

    private void OnMouseDown()
    {
        if (framingTransposer == null || isZoomed) return;
        ZoomIn();
    }

    private void OnMouseUp()
    {
        if (framingTransposer == null || !isZoomed) return;
        ZoomOut();
    }

    private void Update()
    {
        if (isZoomed && framingTransposer != null)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            framingTransposer.Composition.ScreenPosition.x += mouseX;
            framingTransposer.Composition.ScreenPosition.y += mouseY;
        }
    }

    private void ZoomIn()
    {
        StartCoroutine(ScaleDistanceTo(zoomedDistance, zoomDuration));
        isZoomed = true;
    }

    private void ZoomOut()
    {
        StartCoroutine(ScaleDistanceTo(originalDistance, zoomDuration));
        isZoomed = false;
    }

    private IEnumerator ScaleDistanceTo(float targetDistance, float duration)
    {
        float startDistance = framingTransposer.CameraDistance;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            framingTransposer.CameraDistance = Mathf.Lerp(startDistance, targetDistance, t);
            yield return null;
        }

        framingTransposer.CameraDistance = targetDistance;
    }
}
