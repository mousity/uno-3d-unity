using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardSpawner spawner;
    public enum GameState
    {
        StartGame,
        PlayerTurn,
        EnemyTurn,
        Win,
        Lose
    }
    public GameState currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GameState.StartGame;
        spawner.DrawRandomCard();
    }

}
