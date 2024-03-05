using UnityEngine;
using UnityEngine.UI;

public class FishingRod : MonoBehaviour
{
    public LineRenderer lineRenderer; // ������ �� ��������� LineRenderer
    public Transform hook; // ������ �� ������ ������
    public float power = 1f;
    public float hookspeed = 100f;
    public LayerMask trashLayer;
    public Text lifeText; // Reference to the UI Text component

    public GameObject Win;
    public GameObject Res;


    private Vector3 startPosition; // ��������� ������� ������
    private Vector3 endPosition; // �������� ������� ������

    private bool isDragging; // ����, �����������, ��������������� �� ������
    private Vector3 initialMousePosition; // ��������� ������� ���� ��� ��������������
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
        lineRenderer.positionCount = 0; // ���������� ����� �� ��������
        // Calculate the total number of trash in the scene
        totalTrashCount = GameObject.FindGameObjectsWithTag("Trash").Length;

        objectManager = FindObjectOfType<ObjectManager>();
    }

    private void Update()
    {

        lifeText.text = "�����: " + life.ToString();

        if (Input.GetMouseButtonDown(0)) // ���������, ���� ������ ���� ������
        {
            isDragging = true;
            initialMousePosition = Input.mousePosition;

            // ������� ����� � ������������� ��������� ������� ������
            lineRenderer.positionCount = 0;
            startPosition = transform.position;
        }

        if (Input.GetMouseButton(0) && isDragging) // ���������, ���� ������ ���� ���������� ���� ������� � ������ ���������������
        {
            // ������������ �������� ������� ������ � ������������ � ������������ ����
            endPosition = transform.position + (initialMousePosition - Input.mousePosition) * power;
            //endPosition.z = 0f;

            UpdateLineRenderer(); // ��������� ����������� �����

            // ���������� ������ �� ����� ����� ����������
            hook.position = endPosition;
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // ���������, ���� ������ ���� �������� � ������ ���������������
        {
            isDragging = false;

            // ��������� ������ ������ ������ � �������� ������������ � �������
            RaycastHit2D hit = Physics2D.Raycast(endPosition, Vector2.zero, 0f, LayerMask.GetMask("Trash"));

            if (hit.collider != null && hit.collider.CompareTag("Trash")) // ��������� ������������ � ����������� ������
            {
                hit.collider.gameObject.SetActive(false); // ������� ������ ������
                score++;                       // ����������� ������� �����
                                               // ��� ��� ��� ���������� �������� �����
            }

            if (hit.collider != null && hit.collider.CompareTag("Fish")) // ��������� ������������ � ����������� ������
            {
                hit.collider.gameObject.SetActive(false); // ������� ������ ������
                life--;                                  // ����������� ������� �����
                                                         // ��� ��� ��� ���������� �������� �����
            }

            // ���������� ������ �� ����������
            Rigidbody2D hookRigidbody = hook.GetComponent<Rigidbody2D>();
            hookRigidbody.isKinematic = false; // �������� ���������� �������������� � �������
                                               // hookRigidbody.velocity = CalculateHookVelocity(endPosition); // ������ �������� ������ � ������������ � �����������

            // ������� �����
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
        // ������� � ����������� ������� ����� ��� ��������� �����
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(0f, 0f, 0f));

        lineRenderer.SetPosition(1, endPosition);
    }

    /*private Vector2 CalculateHookVelocity(Vector3 endPosition)
    {
        // ������������ ������ ����������� ����� ��������� � �������� ���������
        Vector2 direction = endPosition - startPosition;
        // ����������� ������ �����������
        direction.Normalize();
        // ������ ������������ �������� ����������� ������
        //float speed = 100f;
        // �������� ������ ����������� �� ��������, ����� �������� �������� ����������� ������
        Vector2 velocity = direction * hookspeed;

        return velocity;
    }*/


    public void RestoreObjects()
    {
        if (objectManager != null)
        {
            objectManager.RestoreObjects();
            score = 0; // �������� ������� �����
            life = 3; // �������� ���������� ������
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
            Res.SetActive(false); // ������� ���� ���������
        }
    }

}