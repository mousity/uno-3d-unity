using System.Collections;
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
    public GameObject textBox;
    public EnemyText enemyTextScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBox.SetActive(false);
        currentState = GameState.StartGame; // Set the current state to the start of the game
        enemyTextScript = enemyTextScript.GetComponent<EnemyText>();
        StartCoroutine(enemyTextScript.ScaleBubbleUp(currentState));
        StartCoroutine(spawner.DrawMultipleCards(currentState)); // Testing drawing multiple cards at the start

        while ((currentState != GameState.Win) && (currentState != GameState.Lose)) // While the game is still going
        {
            if (currentState == GameState.PlayerTurn)
            {
                
            }
            break;
        }
    }

}
