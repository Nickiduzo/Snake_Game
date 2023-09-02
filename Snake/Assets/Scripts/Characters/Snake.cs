using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    [SerializeField] private SoundSystem soundSystem;
    [SerializeField] private GameObject losePanel;
    private Vector2 currentDirection = Vector2.right; // Текущее направление движения
    private float timeToMove = 0.5f;
    private List<Transform> bodySegments = new List<Transform>(); // Сегменты тела змейки

    void Start()
    {
        bodySegments.Add(transform);
        CreateBodySegment();
    }

    void FixedUpdate()
    {
        if (timeToMove <= 0f)
        {
            MoveSnake();
            timeToMove = 0.5f;
        }
        else
        {
            timeToMove -= Time.fixedDeltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            losePanel.SetActive(true);
            soundSystem.PlaySound("Block");
        }
        else if (collision.gameObject.CompareTag("Food"))
        {
            collision.gameObject.SetActive(false);
            CreateBodySegment();
            timeToMove += 0.1f;
            Score.IncreaseScore();
            soundSystem.PlaySound("Eat");
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            collision.gameObject.SetActive(false);
            Score.DecreaseScore();
            soundSystem.PlaySound("Bomb");
        }
    }
    private void CreateBodySegment()
    {
        GameObject segment = new GameObject("SnakeSegment");
        segment.transform.position = bodySegments[bodySegments.Count - 1].position;
        bodySegments.Add(segment.transform);
    }

    // Поворот вліво
    public void TurnLeft()
    {
        if (currentDirection == Vector2.up)
        {
            currentDirection = Vector3.left;
            currentDirection = Quaternion.Euler(0, 0, 180) * currentDirection;
        }
        else if (currentDirection == Vector2.left)
        {
            currentDirection = Vector2.down;
            currentDirection = Quaternion.Euler(0, 0, 0) * currentDirection;
        }
        else if (currentDirection == Vector2.down)
        {
            currentDirection = Vector3.right;
            currentDirection = Quaternion.Euler(0, 0, -90) * currentDirection;
        }
        else if (currentDirection == Vector2.right)
        {
            currentDirection = Vector3.up;
        }
    }

    // Поворот вправо
    public void TurnRight()
    {
        if (currentDirection == Vector2.up)
        {
            currentDirection = Vector2.right;
            currentDirection = Quaternion.Euler(0, 0, 0) * currentDirection;
        }
        else if (currentDirection == Vector2.right)
        {
            currentDirection = Vector2.down;
            currentDirection = Quaternion.Euler(0, 0, -90) * currentDirection;
        }
        else if (currentDirection == Vector2.down)
        {
            currentDirection = Vector2.left;
            currentDirection = Quaternion.Euler(0, 0, 180) * currentDirection;
        }
        else if (currentDirection == Vector2.left)
        {
            currentDirection = Vector2.up;
            currentDirection = Quaternion.Euler(0, 0, 0) * currentDirection;
        }
    }

    // Рух змейки
    private void MoveSnake()
    {
        Vector2 previousPosition = transform.position;
        transform.position += (Vector3)currentDirection * 0.25f;

        for (int i = 1; i < bodySegments.Count; i++)
        {
            Vector2 temp = bodySegments[i].position;
            bodySegments[i].position = previousPosition;
            previousPosition = temp;
        }
    }
}
