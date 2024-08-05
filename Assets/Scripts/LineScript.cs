using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public float moveSpeed;
    float xDirection;


    // Tham chiếu đến GameControllerScript để kiểm tra trạng thái game over
    GameControllerScript m_gc;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
        // Tìm đối tượng GameControllerScript trong scene
        m_gc = FindObjectOfType<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra trạng thái game over từ GameControllerScript
        if (m_gc != null && m_gc.IsGameOver())
        {
            // Nếu game over, không thực hiện di chuyển
            return;
        }

        // Lấy giá trị hướng di chuyển từ bàn phím (trái/phải)
        xDirection = Input.GetAxisRaw("Horizontal");

        // Tính toán khoảng cách di chuyển trong mỗi khung hình
        // Dựa trên tốc độ di chuyển, hướng di chuyển, và thời gian giữa các khung hình
        float moveStep = moveSpeed * xDirection * Time.deltaTime;

        // Kiểm tra xem đối tượng có đang ở ngoài ranh giới cho phép không
        // Nếu đang ở giới hạn và tiếp tục di chuyển ra ngoài ngừng di chuyển
        if ((transform.position.x <= -9f && xDirection < 0) || (transform.position.x >= 9f && xDirection > 0))
        {
            return;
        }

        // Cập nhật vị trí của đối tượng theo trục X
        // Thêm khoảng cách di chuyển vào vị trí hiện tại
        transform.position += new Vector3(moveStep, 0, 0);
    }
}
