using UnityEngine;


public enum GameState // Enum options with possible gamestates
    {
        StartGame,
        PlayerTurn,
        EnemyTurn,
        Win,
        Lose
    }

public class GameManager : MonoBehaviour
{
    public CardSpawner spawner; // References the card spawner class

    public GameState currentState; // Reflects the current state of the game

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GameState.StartGame; // Set the current state to the start of the game
        spawner.DrawRandomCard(currentState);
    }

}
