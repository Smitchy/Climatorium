using UnityEngine;

public static class PersistenceManager
{
    private static int currentScore;
    private static int highScore;

    public static void Initialize()
    {
        currentScore = 0;
        highScore = GetHighScore();
    }

    public static void SaveScore(int score)
    {
        currentScore += score;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            SetNewHighScore(highScore);
        } 
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    private static void SetNewHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }
}
