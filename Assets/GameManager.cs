using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}