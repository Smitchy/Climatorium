using UnityEngine;

public static class PersistenceManager
{
    private static int currentScore;
    private static int[] highScore;
    private static int[] highScoreNewValues;
    private static readonly string scoreText = "HighScore";
    private static bool sortIt = false;

    public static void Initialize()
    {
        currentScore = 0;
        highScore = new int[5];
        highScoreNewValues = new int[6];
        highScore = GetHighScore();
    }

    public static void SaveScore(int score)
    {
        currentScore += score;

        for (int i = 0; i < highScore.Length; i++)
        {
            if (currentScore > highScore[i])
            {
                for (int j = 0; j < highScore.Length; j++)
                {
                    highScoreNewValues[j] = highScore[j];
                }
                highScoreNewValues[5] = currentScore;
                sortIt = true;
                break;
            }
        }

        if (sortIt)
        {
            SetScoreToPlayerPrefs(Sort(highScoreNewValues));
            sortIt = false;
        }
        
    }

    private static int[] Sort(int[] highScoreNewValues)
    {
        for (int i = 0; i < highScoreNewValues.Length; i++)
            {
                for (int j = 0; j < highScoreNewValues.Length; j++)
                {
                    if (highScoreNewValues[j] < highScoreNewValues[i])
                    {
                        int temp = highScoreNewValues[i];
                        highScoreNewValues[i] = highScoreNewValues[j];
                        highScoreNewValues[j] = temp;
                    }
                }
            }

        for (int i = 0; i < 5; i++)
        {
            highScore[i] = highScoreNewValues[i];
        }    

        return highScore;
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
        for (int i = 0; i < highScore.Length; i++)
        {
            highScore[i] = PlayerPrefs.GetInt(scoreText + i, 0);
        }

        return highScore;
    }
}
