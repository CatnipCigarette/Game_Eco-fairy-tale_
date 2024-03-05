using UnityEngine;
using UnityEngine.UI;

public class BakMov : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject GameWin;
    public float movementSpeed = 5f; // �������� �������� ��������
    public Text scoreText; // ������ �� ��������� ������ ��� ����������� �����
    public int winScore = 30; // ��������� �������� ��� ������
    public int maxHealth = 3;
    public Text healthText;
    public float minXPosition = -5f; // ����������� ������� �� ��� X
    public float maxXPosition = 5f; // ������������ ������� �� ��� X

    public int score = 0; // ������� ����
    public int health = 3;

    private void Start()
    {
        scoreText.text = "����: " + score.ToString();
        healthText.text = "�����: " + health.ToString();
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
            scoreText.text = "����: " + score.ToString();

            if (score >= winScore)
            {
                WinGame();
            }
        }


        if (collision.CompareTag("badItem"))
        {
            Destroy(collision.gameObject);
            health--;
            healthText.text = "�����: " + health.ToString();

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
