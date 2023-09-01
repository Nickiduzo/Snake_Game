using UnityEngine;

public class Snake : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float gridSize = 1.0f;

    private Vector3 moveDirection = Vector3.right; // ��������� ����������� - ������
    private Vector3 nextMovePosition; // ��������� ������� ��� ��������
    private float nextMoveTime = 0; // ����� ���������� ����

    void Start()
    {
        nextMovePosition = transform.position + moveDirection * gridSize;
        nextMoveTime = Time.time + moveSpeed;
    }

    public void RotateRight()
    {
        if (moveDirection != Vector3.left) // ��������� ��������������� �����
        {
            moveDirection = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 0, 0); // ������� ������
        }
    }

    public void RotateLeft()
    {
        if (moveDirection != Vector3.right) // ��������� ��������������� �����
        {
            moveDirection = Vector3.left;
            transform.rotation = Quaternion.Euler(0, 180, 0); // ������� �����
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
