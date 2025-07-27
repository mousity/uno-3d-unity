using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.XR.Haptics;

public class CardSpawner : MonoBehaviour
{
    // GameObject to hold the card we will spawn
    public GameObject cardPrefab;
    // Deck filled with all possible cards one could pull
    public List<CardData> deck;
    public GameObject topCard;
    public Transform playerHand;
    public Transform enemyHand;
    private ArcCards arcer;
    private int cardsToDraw = 7;
    private float drawDelay = 0.5f;
    private float drawDelayStart = 0.25f;
    public Transform enemyPoint;
    public Transform playerPoint;
    public bool animating = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public IEnumerator DrawMultipleCards(GameState currentState)
    {
        if (currentState == GameState.StartGame)
        {
            for (int i = 0; i < cardsToDraw; i++) // For amount of cards to be drawn
            {
                DrawRandomCard(GameState.PlayerTurn);
                yield return new WaitForSeconds(drawDelayStart);
                DrawRandomCard(GameState.EnemyTurn);
                yield return new WaitForSeconds(drawDelayStart);
                Debug.Log("check");
            }

        }

    }

    public GameObject DrawRandomCard(GameState currentState)
    {
        // Generate random index to pick out a card in the list
        int index = Random.Range(0, deck.Count);
        GameObject newCard;
        Quaternion cardRotation = new Quaternion(-90, 0, 0, 0);
        //Vector3 pos = new Vector3(2, 2, 1); // Test positional vector

        CardData card = deck[index]; // Grab random card
        newCard = Instantiate(cardPrefab, topCard.transform.position, cardRotation);


        // Instantiate card prefab with position and upright rotation
        if (currentState == GameState.PlayerTurn)
        {
            newCard.transform.SetParent(playerHand, worldPositionStays: false); // Sets parent to playerHand
        }
        else if (currentState == GameState.EnemyTurn)
        {
            newCard.transform.SetParent(enemyHand, worldPositionStays: false); // Sets parents to enemyHand
        }

        CardDisplay display = newCard.GetComponent<CardDisplay>(); // Get the display component of the new card we instantiated
        newCard.name = card.type.ToString() + card.color.ToString() + card.number.ToString(); // Names the object in the editor

        display.SetCardData(card); // Set the cardData to be a random card
        StartCoroutine(Animate(newCard, currentState));
        return newCard; // Return newly created card
    }


    IEnumerator Animate(GameObject card, GameState state)
    {
        animating = true;
        Vector3 tempPos = card.transform.position;
        float t = 0;
        Transform point = state == GameState.PlayerTurn ? playerPoint : enemyPoint;
        Quaternion rotation = state == GameState.EnemyTurn ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, 0f, 0f);
        while (t < 1f)
        {
            t += Time.deltaTime;
            card.transform.position = Vector3.Lerp(tempPos, point.position, t);
            card.transform.rotation = Quaternion.Slerp(Quaternion.Euler(-90f, 0f, 0f), rotation, t);
            yield return null;  // Wait one frame
        }
        animating = false;
    }

}
