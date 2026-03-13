using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public double score = 0;
    public double incrementPerSecond = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI incrementText;
    public double incrementCost = 10;
    public double incrementMultiplier = 1;
    public TextMeshProUGUI upgradeButtonText;

    void Start()
    {
        InvokeRepeating("AutoIncrement", 1f, 1f);
        UpdateScoreText();
        UpdateIncrementText();
    }

    void AutoIncrement()
    {
        score += incrementPerSecond;
        UpdateScoreText();
    }

    public void IncreaseIncrement()
    {
        if (score >= incrementCost)
        {
            score -= incrementCost;
            incrementPerSecond += incrementMultiplier;
            incrementCost *= 1.5;
            UpdateScoreText();
            UpdateIncrementText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = FormatNumber(score);
    }

    void UpdateIncrementText()
    {
        incrementText.text = "Rate: " + FormatNumber(incrementPerSecond);
        upgradeButtonText.text = "Upgrade (" + FormatNumber(incrementCost) + ")";
    }

    string FormatNumber(double number)
    {
        if (number >= 1_000_000_000)
            return (number / 1_000_000_000D).ToString("0.##") + "B";
        else if (number >= 1_000_000)
            return (number / 1_000_000D).ToString("0.##") + "M";
        else if (number >= 1_000)
            return (number / 1_000D).ToString("0.##") + "k";
        else
            return number.ToString("0");
    }
}