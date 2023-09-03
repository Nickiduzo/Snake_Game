using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject bodySegment;
    private List<GameObject> snakeSegments;
    private Vector2 currentDirection = Vector2.right;
    private Vector2 lastPosition;

    private float moveInterval = 0.5f;
    private float timer = 0f;
    private void Start()
    {
        snakeSegments = new List<GameObject>();
        CreateNewSegment();
        lastPosition = transform.position;
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= moveInterval)
        {
            MoveSnake();
            timer = 0f; 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Food"))
        {
            Score.IncreaseScore();
            CreateNewSegment();
        }
        else if (collision.collider.gameObject.CompareTag("Bomb"))
        {
            Score.DecreaseScore();
        }
        else
        {
            losePanel.SetActive(true);
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

        for (int i = snakeSegments.Count - 1; i >= 0; i--)
        {
            Vector2 segmentPosition = transform.position;

            snakeSegments[i].transform.position = lastPosition;
            lastPosition = segmentPosition;
        }
    }
    private void CreateNewSegment()
    {
        Vector2 newSegmentPosition = (Vector2)transform.position - currentDirection * 0.25f;
        GameObject newSegment = Instantiate(bodySegment, newSegmentPosition, Quaternion.identity);
        snakeSegments.Add(newSegment);
    }
}
