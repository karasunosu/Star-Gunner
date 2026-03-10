using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0; // score hien tai (show tren man hinh)

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();    
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        score = Mathf.Clamp(score, 0, int.MaxValue);
        print(score);
    }

    public int GetScore()
    {
        return score;
    }
}
