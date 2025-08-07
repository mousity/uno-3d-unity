using System.Collections;
using Unity.VisualScripting;
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
    public PlayAreaManager playArea;
    public Transform playAreaObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playArea = playAreaObject.GetComponent<PlayAreaManager>();
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
        if (Input.GetMouseButtonDown(0)) // If we click
        {
            if (Physics.Raycast(rayObj, out rayHit, 20f) && currentState != GameState.StartGame) // And if the raycast hit a valid object
            {
                GameObject hitObject = rayHit.collider.gameObject;
                Transform parent = hitObject.transform.parent;

                if (parent.CompareTag("Deck")) // If the hit object is the deck
                {
                    Debug.Log(currentState);
                    spawner.DrawRandomCard(currentState); // Draw a card
                }
                else if (parent.CompareTag("PlayerHand"))
                {
                    CardData recentCard = playArea.GetMostRecentCard().GetComponent<CardDisplay>().cardData;
                    CardData hoveredCard = hitObject.GetComponent<CardDisplay>().cardData;
                    Debug.Log("PLAYER HAND!");
                    if ((recentCard.color == hoveredCard.color) || (recentCard.number == hoveredCard.number))
                    {
                        hitObject.transform.SetParent(playAreaObject);
                    }
                }
            }
        }
    }

    public IEnumerator GameLoop()
    {
        while ((currentState != GameState.Win) && (currentState != GameState.Lose)) // While the game is still going
        {
            if (currentState == GameState.PlayerTurn) // If it's the player's turn
            {
                turnFinished = false;
                StartCoroutine(PlayerTurn());
                yield return new WaitUntil(() => turnFinished);
                currentState = GameState.EnemyTurn;
            }
            else if (currentState == GameState.EnemyTurn) // If it's the enemy's turn
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
        StartCoroutine(enemyTextScript.ScaleBubbleUp(currentState)); // Start the enemy's dialogue
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(spawner.DrawMultipleCards(currentState)); // Start drawing all cards
        textBox.SetActive(false); // Turn off the textBox
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

    public void PlayCard()
    {
        //if()
    }

}
