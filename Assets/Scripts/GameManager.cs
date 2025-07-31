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
    public bool turnFinished;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBox.SetActive(false);
        turnFinished = true;

        currentState = GameState.StartGame; // Set the current state to the start of the game
        enemyTextScript = enemyTextScript.GetComponent<EnemyText>();

        StartCoroutine(StartGame());
    }

    public IEnumerator GameLoop()
    {
        while ((currentState != GameState.Win) && (currentState != GameState.Lose)) // While the game is still going
        {
            if (currentState == GameState.PlayerTurn)
            {
                turnFinished = false;
                StartCoroutine(PlayerTurn());
                yield return new WaitUntil(() => turnFinished);
                currentState = GameState.EnemyTurn;
            }
            else if (currentState == GameState.EnemyTurn)
            {
                turnFinished = false;
                StartCoroutine(EnemyTurn());
                yield return new WaitUntil(() => turnFinished);
                currentState = GameState.PlayerTurn;
            }
        }

    }

    IEnumerator StartGame()
    {
        StartCoroutine(enemyTextScript.ScaleBubbleUp(currentState));

        yield return new WaitForSeconds(1f);

        StartCoroutine(spawner.DrawMultipleCards(currentState));
    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(0.1f);
    }

}
