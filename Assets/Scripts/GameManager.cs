using System.Collections;
using UnityEditor;
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
    private Ray rayObj;
    private RaycastHit rayHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBox.SetActive(false);
        turnFinished = true;
        currentState = GameState.StartGame; // Set the current state to the start of the game
        enemyTextScript = enemyTextScript.GetComponent<EnemyText>();
        StartCoroutine(StartGame());
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition; // 3D vector to point to current position of mouse
        rayObj = Camera.main.ScreenPointToRay(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(rayObj, out rayHit, 20f) && currentState != GameState.StartGame)
            {
                GameObject hitObject = rayHit.collider.gameObject;
                Transform parent = hitObject.transform.parent;

                if (parent.CompareTag("Deck"))
                {
                    Debug.Log(currentState);
                    spawner.DrawRandomCard(currentState);
                }
            }
        }
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
        currentState = GameState.PlayerTurn;
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
