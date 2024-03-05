using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float horizontalSpeed = 1f;
    public float verticalRange = 0.5f;
    public bool isMovingRight = true; // Поле для определения направления движения

    private SpriteRenderer spriteRenderer;

    private float initialY;
    private float minX;
    private float maxX;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        initialY = transform.position.y;

        // Определение границ движения по горизонтали
        SpriteRenderer backgroundSpriteRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        float backgroundWidth = backgroundSpriteRenderer.bounds.size.x;
        float trashWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        minX = backgroundSpriteRenderer.bounds.min.x + trashWidth / 2;
        maxX = backgroundSpriteRenderer.bounds.max.x - trashWidth / 2;
    }

    private void Update()
    {
        // Горизонтальное движение
        float horizontalMovement = horizontalSpeed * Time.deltaTime * (isMovingRight ? 1 : -1);
        transform.Translate(Vector3.right * horizontalMovement);

        // Изменение направления при достижении границы
        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            isMovingRight = !isMovingRight;
            // Отзеркаливаем изображение мусора
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // Вертикальное движение (плавание на волнах)
        float yOffset = Mathf.Sin(Time.time * horizontalSpeed) * verticalRange;
        transform.position = new Vector3(transform.position.x, initialY + yOffset, transform.position.z);
    }
}