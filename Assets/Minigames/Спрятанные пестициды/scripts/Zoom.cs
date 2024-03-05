using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Camera mainCamera;
    public Camera additionalCamera;
    public float zoomedCameraZ = -5f; // Ќова€ координата Z дл€ дополнительной камеры

    private bool isZoomed = false;
    private Vector3 originalPosition;
    private Vector3 zoomedPosition;

    private void Start()
    {
        originalPosition = additionalCamera.transform.position;
        zoomedPosition = originalPosition;
        zoomedPosition.z = zoomedCameraZ;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = true;
            additionalCamera.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition) + zoomedPosition;
            additionalCamera.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(false);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isZoomed = false;
            additionalCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
        }

        if (isZoomed)
        {
            additionalCamera.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition) + zoomedPosition;
        }
    }
}
