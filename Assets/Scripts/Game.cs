using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private RestartScreen _restartScreen;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _restartScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
        _enemySpawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _restartScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
        _enemySpawner.EnemySpawned -= OnEnemySpawned;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _restartScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _restartScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _scoreCounter.Reset();
        _bird.Reset();
    }
    
    private void OnEnemySpawned(Enemy enemy)
    {
        enemy.Died += OnEnemyDied;
        enemy.ReadyToReturn += OnEnemyRemoved;
    }
    
    private void OnEnemyDied(Enemy enemy)
    {
        _scoreCounter.Add();
    }
    
    private void OnEnemyRemoved(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        enemy.ReadyToReturn -= OnEnemyRemoved;
    }
}