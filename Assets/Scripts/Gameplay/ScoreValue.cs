using UnityEngine;

// Dat o object co score (enemy)

public class ScoreValue : MonoBehaviour
{
    [SerializeField] int score;

    public int GetScoreValue()
    {
        return score;
    }
}
