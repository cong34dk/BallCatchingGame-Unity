using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Text để hiển thị điểm số
    public Text scoreText;

    // Bảng hiển thị khi trò chơi kết thúc
    public GameObject gameoverPanel;

    // Cập nhật text hiển thị điểm số
    public void SetScoreText(string txt)
    {
        if (scoreText)
            scoreText.text = txt;
    }

    // Hiển thị hoặc ẩn bảng game over
    public void ShowGameOverPanel(bool isShow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.SetActive(isShow);
        }
    }

    // Phương thức Start được gọi một lần khi script bắt đầu
    void Start()
    {

    }

    // Phương thức Update được gọi mỗi khung hình
    void Update()
    {

    }
}
