using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    private Renderer backgroundRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        backgroundRenderer = GameObject.FindGameObjectWithTag("Background").GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        // ќграничение передвижени€ камеры в пределах фона
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;

        float minX = backgroundRenderer.bounds.min.x + cameraHalfWidth;
        float maxX = backgroundRenderer.bounds.max.x - cameraHalfWidth;
        float minY = backgroundRenderer.bounds.min.y + cameraHalfHeight;
        float maxY = backgroundRenderer.bounds.max.y - cameraHalfHeight;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        transform.position = targetPosition;
    }
}
