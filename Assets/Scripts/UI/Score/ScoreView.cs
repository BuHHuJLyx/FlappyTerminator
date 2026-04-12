using TMPro;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _text.text = score.ToString();
    }
}