using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private Vector3 lastPosition; // ��������� ������� ���
    private float moveDelay = 0.5f; // �������� �� �������
    
    private void Start()
    {
        lastPosition = transform.position;
    }
    public void MoveAfterDelay()
    {
        transform.position = lastPosition;
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (moveDelay <= 0)
        {
            MoveAfterDelay();
        }
        else
        {
            moveDelay -= Time.deltaTime;
        }
    }
}
