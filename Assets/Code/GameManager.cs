using System;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    private float _score;
    public float Score { get { return _score; } }

    public static Action OnScoreChange;

    public void AddScore(float value = 100)
    {
        this._score += value;
        OnScoreChange();
    }
}
