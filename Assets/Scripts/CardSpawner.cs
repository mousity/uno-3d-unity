using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    // GameObject to hold the card we will spawn
    public GameObject cardPrefab;
    // Deck filled with all possible cards one could pull
    public List<CardData> deck;

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


    public GameObject DrawRandomCard()
    {
        // Generate random index to pick out a card in the list
        int index = Random.Range(0, deck.Count);
        Vector3 pos = new Vector3(2, 2, 1); // Test positional vector

        CardData card = deck[index]; // Grab random card

        // Instantiate card prefab with position and no rotation
        GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
        CardDisplay display = newCard.GetComponent<CardDisplay>(); // Get the display component of the new card we instantiated
        newCard.name = card.type.ToString() + card.color.ToString() + card.number.ToString(); // Names the object in the editor

        display.SetCardData(card); // Set the cardData to be a random card
        return newCard;
    }
}
