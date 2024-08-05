using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Tham chiếu đến script điều khiển trò chơi
    GameControllerScript m_gc;

    // Phương thức Start được gọi khi script bắt đầu
    private void Start()
    {
        // Tìm đối tượng GameControllerScript trong scene
        m_gc = FindObjectOfType<GameControllerScript>();
    }

    // Xử lý sự kiện va chạm 2D với một collider khác
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra xem va chạm có xảy ra với đối tượng có tag "Player" không
        if (collision.gameObject.CompareTag("Player"))
        {
            // Tăng điểm khi va chạm với người chơi
            m_gc.IncrementScore();

            // Hủy đối tượng quả bóng sau khi va chạm
            Destroy(gameObject);

            Debug.Log("Qua bong da va cham voi gia do");
        }
    }

    // Xử lý sự kiện khi quả bóng đi vào một vùng kích hoạt (trigger) 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem va chạm có xảy ra với đối tượng có tag "DeathZone" không
        if (collision.CompareTag("DeathZone"))
        {
            // Đặt trạng thái game over trong GameControllerScript
            m_gc.SetGameOverState(true);

            // Hủy đối tượng quả bóng sau khi va chạm
            Destroy(gameObject);

            Debug.Log("Qua bong va cham voi DeathZone, GameOver");
        }
    }
}
