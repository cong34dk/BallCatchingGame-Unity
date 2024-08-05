using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    // Đối tượng quả bóng sẽ được tạo
    public GameObject ball;

    // Thời gian chờ giữa các lần tạo quả bóng
    public float spawnTime;

    // Biến lưu trữ thời gian chờ hiện tại giữa các lần tạo quả bóng
    float m_spawnTime;

    // Điểm số hiện tại
    int m_score;

    // Trạng thái trò chơi: đã kết thúc hay chưa
    bool m_isGameOver;

    // Tham chiếu đến UIManager để quản lý UI
    UIManager m_ui;

    // Phương thức Start được gọi khi script bắt đầu
    void Start()
    {
        // Khởi tạo biến thời gian chờ
        m_spawnTime = 0;

        // Đặt trạng thái ban đầu là không game over
        m_isGameOver = false;

        // Tìm UIManager trong scene
        m_ui = FindObjectOfType<UIManager>();

        // Cập nhật UI với điểm số ban đầu
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Phương thức Update được gọi mỗi khung hình
    void Update()
    {
        // Giảm thời gian chờ theo thời gian trôi qua
        m_spawnTime -= Time.deltaTime;

        // Nếu trò chơi đã kết thúc, hiển thị bảng game over và dừng tạo bóng
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }

        // Khi thời gian chờ đã hết, tạo một quả bóng mới
        if (m_spawnTime <= 0)
        {
            SpawnBall();

            // Đặt lại thời gian chờ cho lần tạo tiếp theo
            m_spawnTime = spawnTime;
        }
    }

    // Tạo một quả bóng tại vị trí ngẫu nhiên
    public void SpawnBall()
    {
        // Tạo vị trí xuất hiện ngẫu nhiên cho quả bóng
        Vector2 spawnPos = new Vector2(Random.Range(-12, 12), 9);

        // Nếu có đối tượng bóng được đặt, tạo một quả bóng mới
        if (ball)
        {
            Instantiate(ball, spawnPos, Quaternion.identity);
        }
    }

    // Phương thức cho phép bắt đầu lại trò chơi
    public void Replay()
    {
        // Đặt lại điểm số và trạng thái trò chơi
        m_score = 0;
        m_isGameOver = false;

        // Cập nhật lại UI cho điểm số và bảng game over
        m_ui.SetScoreText("Score: " + m_score);
        m_ui.ShowGameOverPanel(false);
    }

    // Đặt điểm số
    public void SetScore(int value)
    {
        m_score = value;
    }

    // Lấy điểm số hiện tại
    public int GetScore(int value)
    {
        return m_score;
    }

    // Tăng điểm số khi người chơi ghi điểm
    public void IncrementScore()
    {
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Trả về trạng thái game over
    public bool IsGameOver()
    {
        return m_isGameOver;
    }

    // Thiết lập trạng thái game over
    public void SetGameOverState(bool value)
    {
        m_isGameOver = value;
    }
}
