using UnityEngine;

public static class PersistenceManager
{
    private static int currentScore;
    private static int[] highScore;
    private static int[] highScoreNewValues;
    private static readonly string scoreText = "Hiscore";
    private static bool highscoreBeaten = false;

    public static void Initialize()
    {
        currentScore = 0;
        highScore = GetHighScore();
        highScore = new int[5];
        highScoreNewValues = new int[6];
    }

    public static void SaveScore(int score)
    {
        //Shift hiscore down and slot new hiscore in
        currentScore += score;
        for (int i = 0; i < 5; i++)
        {
            if (highScore[i] < currentScore)
            {
                highScore[highScore.Length] = 0;
                highscoreBeaten = true;
            }
            if (highscoreBeaten)
            {
                highScoreNewValues[i + 1] = highScore[i];
            }
            else
            {
                highScoreNewValues[i] = highScore[i];
            }
        }
        if (highscoreBeaten)
        {
            SetScoreToPlayerPrefs(highScoreNewValues);
        }
        highscoreBeaten = false;
    }
    private static void SetScoreToPlayerPrefs(int[] newValues)
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(scoreText + i, newValues[i]);
        }
    }
    public static int[] GetHighScore()
    {
        for (int i = 0; i < 5; i++)
        {
            highScore[i] = PlayerPrefs.GetInt(scoreText + i);
        }
        return highScore;
    }

    private static void SetNewHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }
}
