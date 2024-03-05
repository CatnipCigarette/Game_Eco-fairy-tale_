using UnityEngine;
using UnityEngine.UI;

public class FishingRod : MonoBehaviour
{
    public LineRenderer lineRenderer; // Ссылка на компонент LineRenderer
    public Transform hook; // Ссылка на объект крючка
    public float power = 1f;
    public float hookspeed = 100f;
    public LayerMask trashLayer;
    public Text lifeText; // Reference to the UI Text component

    public GameObject Win;
    public GameObject Res;


    private Vector3 startPosition; // Начальная позиция удочки
    private Vector3 endPosition; // Конечная позиция удочки

    private bool isDragging; // Флаг, указывающий, перетаскивается ли удочка
    private Vector3 initialMousePosition; // Начальная позиция мыши при перетаскивании
    public int score = 0; // Score counter
    private int totalTrashCount; // Total number of trash in the scene
    public int life = 3;

    public GameObject Fish1;
    public GameObject Fish2;
    public GameObject Fish3;
    public GameObject Trash1;
    public GameObject Trash2;
    public GameObject Trash3;
    public GameObject Trash4;
    public GameObject Trash5;
    public GameObject Trash6;
    public GameObject Hooook;
    private ObjectManager objectManager;

    private void Start()
    {
        lineRenderer.positionCount = 0; // Изначально линия не рисуется
        // Calculate the total number of trash in the scene
        totalTrashCount = GameObject.FindGameObjectsWithTag("Trash").Length;

        objectManager = FindObjectOfType<ObjectManager>();
    }

    private void Update()
    {

        lifeText.text = "Жизни: " + life.ToString();

        if (Input.GetMouseButtonDown(0)) // Проверяем, если кнопка мыши нажата
        {
            isDragging = true;
            initialMousePosition = Input.mousePosition;

            // Очищаем линию и устанавливаем начальную позицию удочки
            lineRenderer.positionCount = 0;
            startPosition = transform.position;
        }

        if (Input.GetMouseButton(0) && isDragging) // Проверяем, если кнопка мыши продолжает быть нажатой и удочка перетаскивается
        {
            // Рассчитываем конечную позицию удочки в соответствии с перемещением мыши
            endPosition = transform.position + (initialMousePosition - Input.mousePosition) * power;
            //endPosition.z = 0f;

            UpdateLineRenderer(); // Обновляем отображение линии

            // Перемещаем крючок на конец линии траектории
            hook.position = endPosition;
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // Проверяем, если кнопка мыши отпущена и удочка перетаскивалась
        {
            isDragging = false;

            // Реализуем логику броска крючка и проверки столкновения с мусором
            RaycastHit2D hit = Physics2D.Raycast(endPosition, Vector2.zero, 0f, LayerMask.GetMask("Trash"));

            if (hit.collider != null && hit.collider.CompareTag("Trash")) // Проверяем столкновение с коллайдером мусора
            {
                hit.collider.gameObject.SetActive(false); // Удаляем объект мусора
                score++;                       // Увеличиваем счетчик очков
                                               // Ваш код для увеличения счетчика очков
            }

            if (hit.collider != null && hit.collider.CompareTag("Fish")) // Проверяем столкновение с коллайдером мусора
            {
                hit.collider.gameObject.SetActive(false); // Удаляем объект мусора
                life--;                                  // Увеличиваем счетчик очков
                                                         // Ваш код для увеличения счетчика очков
            }

            // Перемещаем крючок по траектории
            Rigidbody2D hookRigidbody = hook.GetComponent<Rigidbody2D>();
            hookRigidbody.isKinematic = false; // Включаем физическое взаимодействие с крючком
                                               // hookRigidbody.velocity = CalculateHookVelocity(endPosition); // Задаем скорость крючка в соответствии с траекторией

            // Очищаем линию
            lineRenderer.positionCount = 0;


        }

        // Check if there is no more trash remaining
        if (score == totalTrashCount)
        {
            Win.SetActive(true);
        }

        if (life == 0)
        {
            Hooook.SetActive(false);
            Res.SetActive(true);
        }

    }

    private void UpdateLineRenderer()
    {
        // Очищаем и настраиваем позиции точек для отрисовки линии
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(0f, 0f, 0f));

        lineRenderer.SetPosition(1, endPosition);
    }

    /*private Vector2 CalculateHookVelocity(Vector3 endPosition)
    {
        // Рассчитываем вектор направления между начальной и конечной позициями
        Vector2 direction = endPosition - startPosition;
        // Нормализуем вектор направления
        direction.Normalize();
        // Задаем максимальную скорость перемещения крючка
        //float speed = 100f;
        // Умножаем вектор направления на скорость, чтобы получить скорость перемещения крючка
        Vector2 velocity = direction * hookspeed;

        return velocity;
    }*/


    public void RestoreObjects()
    {
        if (objectManager != null)
        {
            objectManager.RestoreObjects();
            score = 0; // Сбросьте счетчик очков
            life = 3; // Сбросьте количество жизней
            Fish1.SetActive(true);
            Fish2.SetActive(true);
            Fish3.SetActive(true);
            Trash1.SetActive(true);
            Trash2.SetActive(true);
            Trash3.SetActive(true);
            Trash4.SetActive(true);
            Trash5.SetActive(true);
            Trash6.SetActive(true);
            Hooook.SetActive(true);
            Res.SetActive(false); // Скройте окно поражения
        }
    }

}