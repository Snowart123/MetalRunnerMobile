using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public Camera mainCamera;

    public float zoomSpeed;

    public float minFieldOfView;
    public float maxFieldOfView;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0Previous = touch0.position - touch0.deltaPosition;
            Vector2 touch1Previous = touch1.position - touch1.deltaPosition;

            float previousDistance = Vector2.Distance(touch0Previous, touch1Previous);
            float currentDistance = Vector2.Distance(touch0.position, touch1.position);

            float difference = currentDistance - previousDistance;

            // Adjust the camera's Field of View
            mainCamera.fieldOfView -= difference * zoomSpeed;

            // Keep the zoom within the camera's limits
            mainCamera.fieldOfView = Mathf.Clamp(
                mainCamera.fieldOfView,
                minFieldOfView,
                maxFieldOfView
            );
        }
    }
}