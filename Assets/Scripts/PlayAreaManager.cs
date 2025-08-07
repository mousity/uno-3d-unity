using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayAreaManager : MonoBehaviour
{
    private int cardCount = 4;
    public CardData[] CardArray;
    private Queue<GameObject> cardPile;
    private GameObject mostRecentCard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetMostRecentCard()
    {
        return mostRecentCard;
    }

    public void ModifyPlayArea(GameObject cardToPlay)
    {
        if (cardPile.Count < cardCount)
        {
            cardPile.Enqueue(cardToPlay);
        }
        else
        {
            cardPile.Dequeue();
            cardPile.Enqueue(cardToPlay);
        }

        mostRecentCard = cardToPlay;
    }

    public void SetMostRecentCard(GameObject card)
    {
        mostRecentCard = card;
        cardPile.Enqueue(mostRecentCard);
    }
}
