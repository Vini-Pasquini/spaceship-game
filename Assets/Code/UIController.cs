using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private TextMeshProUGUI _scoreDisplay;

    private void OnEnable()
    {
        GameManager.OnScoreChange += OnScoreChangeCallback;
    }

    private void OnDisable()
    {
        GameManager.OnScoreChange -= OnScoreChangeCallback;
    }

    private void OnScoreChangeCallback()
    {
        this._scoreDisplay.text = $"SCORE: {GameManager.Instance.Score}";
    }
}
