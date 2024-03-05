using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;  // Скорость движения фона
    public float verticalMovementRange = 1.0f;  // Диапазон вертикального движения

    private Transform backgroundObjectTransform;
    private Vector3 initialPosition;

    void Start()
    {
        backgroundObjectTransform = transform;
        initialPosition = backgroundObjectTransform.position;
    }

    void Update()
    {
        float verticalOffset = Mathf.Sin(Time.time * scrollSpeed) * verticalMovementRange;
        backgroundObjectTransform.position = initialPosition + new Vector3(0, verticalOffset, 0);
    }
}