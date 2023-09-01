using UnityEngine;

public class Snake : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float gridSize = 1.0f;

    private Vector3 moveDirection = Vector3.right; // Начальное направление - вправо
    private Vector3 nextMovePosition; // Следующая позиция для движения
    private float nextMoveTime = 0; // Время следующего шага

    void Start()
    {
        nextMovePosition = transform.position + moveDirection * gridSize;
        nextMoveTime = Time.time + moveSpeed;
    }

    public void RotateRight()
    {
        if (moveDirection != Vector3.left) // Запрещаем разворачиваться назад
        {
            moveDirection = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 0, 0); // Поворот вправо
        }
    }

    public void RotateLeft()
    {
        if (moveDirection != Vector3.right) // Запрещаем разворачиваться назад
        {
            moveDirection = Vector3.left;
            transform.rotation = Quaternion.Euler(0, 180, 0); // Поворот влево
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = nextMovePosition;
        nextMovePosition += moveDirection * gridSize;
        nextMoveTime = Time.time + moveSpeed;
    }
}
