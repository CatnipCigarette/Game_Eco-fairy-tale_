using UnityEngine;
using UnityEngine.UI;

public class BakMov : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject GameWin;
    public float movementSpeed = 5f; // Скорость движения корзинки
    public Text scoreText; // Ссылка на текстовый объект для отображения счета
    public int winScore = 30; // Пороговое значение для победы
    public int maxHealth = 3;
    public Text healthText;
    public float minXPosition = -5f; // Минимальная позиция по оси X
    public float maxXPosition = 5f; // Максимальная позиция по оси X

    public int score = 0; // Текущий счет
    public int health = 3;

    private void Start()
    {
        scoreText.text = "Счёт: " + score.ToString();
        healthText.text = "Жизни: " + health.ToString();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float movement = horizontalInput * movementSpeed * Time.deltaTime;
        transform.Translate(movement, 0f, 0f);
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x + movement, minXPosition, maxXPosition);
        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Счёт: " + score.ToString();

            if (score >= winScore)
            {
                WinGame();
            }
        }


        if (collision.CompareTag("badItem"))
        {
            Destroy(collision.gameObject);
            health--;
            healthText.text = "Жизни: " + health.ToString();

            if (health <= 0)
            {
                LoseGame();
            }
        }
    }

    private void WinGame()
    {
        GameWin.SetActive(true);
        Time.timeScale = 0f;
    }

    private void LoseGame()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
