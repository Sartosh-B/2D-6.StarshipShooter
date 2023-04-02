using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;



    public int GetCurrentScore()
    {
        return currentScore;
    }
    public void AddToScore(int pointsToAdd)
    {
        currentScore += pointsToAdd;
    }
    public void ResetScore()
    {
        currentScore = 0;
    }
}
