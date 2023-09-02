using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject snakeSegment;
    private List<GameObject> snakeSegments;
    private Vector2 currentDirection = Vector2.right;

    private float moveInterval = 0.5f;
    private float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= moveInterval)
        {
            MoveSnake();
            timer = 0f; 
        }
    }
    public void LeftArrow()
    {
        RotateSnake(90f);
    }

    public void RightArrow()
    {
        RotateSnake(-90f);
    }
    private void RotateSnake(float angle)
    {
        float currentAngle = transform.eulerAngles.z;

        currentAngle += angle;

        transform.eulerAngles = new Vector3(0f, 0f, currentAngle);

        currentDirection = Quaternion.Euler(0f, 0f, angle) * currentDirection;
    }
    private void MoveSnake()
    {
        Vector2 newHeadPosition = (Vector2)transform.position + currentDirection * 0.25f;

        transform.position = newHeadPosition;
    }
}
