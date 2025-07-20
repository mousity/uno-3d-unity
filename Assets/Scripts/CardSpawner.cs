using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CardSpawner : MonoBehaviour
{

    // GameObject to hold the card we will spawn
    public GameObject cardPrefab;
    // Deck filled with all possible cards one could pull
    public List<CardData> deck;
    public GameObject topCard;
    public Transform playerHand;
    public Transform enemyHand;

    private int cardsToDraw = 7;
    private float drawDelay = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Function to draw random card once for testing
        // DrawRandomCard();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public IEnumerator DrawMultipleCards(GameState currentState) 
    {
        for (int i = 0; i < cardsToDraw; i++) // For amount of cards to be drawn
        {
            DrawRandomCard(currentState);
            yield return new WaitForSeconds(drawDelay);
            Debug.Log("check");
        }
    }

    public GameObject DrawRandomCard(GameState currentState)
    {
        // Generate random index to pick out a card in the list
        int index = Random.Range(0, deck.Count);
        GameObject newCard;
        Quaternion cardRotation = new Quaternion(0, 0, 0, 0);
        if (currentState == GameState.EnemyTurn) cardRotation.y = 180;
        //Vector3 pos = new Vector3(2, 2, 1); // Test positional vector

        CardData card = deck[index]; // Grab random card
        newCard = Instantiate(cardPrefab, topCard.transform.position, cardRotation);
        // Instantiate card prefab with position and upright rotation
        if (currentState == GameState.PlayerTurn)
        {
            newCard.transform.SetParent(playerHand, worldPositionStays: false);
        }
        else if (currentState == GameState.EnemyTurn)
        {
            newCard.transform.SetParent(enemyHand, worldPositionStays: false);
        }

        CardDisplay display = newCard.GetComponent<CardDisplay>(); // Get the display component of the new card we instantiated
        newCard.name = card.type.ToString() + card.color.ToString() + card.number.ToString(); // Names the object in the editor

        display.SetCardData(card); // Set the cardData to be a random card
        return newCard; // Return newly created card
    }
}
