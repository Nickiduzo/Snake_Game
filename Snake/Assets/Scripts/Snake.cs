using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    private Vector2 currentDirection = Vector2.right; // Текущее направление движения
    private float timeToMove = 0.5f;
    private List<Transform> bodySegments = new List<Transform>(); // Сегменты тела змейки

    void Start()
    {
        // Изначально змейка состоит из двух сегментов
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
            Time.timeScale = 0f;
            losePanel.SetActive(true);
        }
    }

    // Создать новый сегмент тела змейки
    private void CreateBodySegment()
    {
        GameObject segment = new GameObject("SnakeSegment");
        segment.transform.position = bodySegments[bodySegments.Count - 1].position;
        bodySegments.Add(segment.transform);
    }

    // Повернуть влево
    public void TurnLeft()
    {
        if (currentDirection == Vector2.up)
        {
            currentDirection = Vector2.left;
        }
        else if (currentDirection == Vector2.left)
        {
            currentDirection = Vector2.down;
        }
        else if (currentDirection == Vector2.down)
        {
            currentDirection = Vector2.right;
        }
        else if (currentDirection == Vector2.right)
        {
            currentDirection = Vector2.up;
        }
    }

    // Повернуть вправо
    public void TurnRight()
    {
        if (currentDirection == Vector2.up)
        {
            currentDirection = Vector2.right;
        }
        else if (currentDirection == Vector2.right)
        {
            currentDirection = Vector2.down;
        }
        else if (currentDirection == Vector2.down)
        {
            currentDirection = Vector2.left;
        }
        else if (currentDirection == Vector2.left)
        {
            currentDirection = Vector2.up;
        }
    }

    // Двигать змейку
    private void MoveSnake()
    {
        // Двигаем каждый сегмент тела
        for (int i = bodySegments.Count - 1; i > 0; i--)
        {
            bodySegments[i].position = bodySegments[i - 1].position;
        }

        // Двигаем голову
        Vector2 newHeadPosition = (Vector2)transform.position + currentDirection * 0.25f;
        transform.position = newHeadPosition;
    }
}
