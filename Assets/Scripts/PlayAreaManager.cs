using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayAreaManager : MonoBehaviour
{
    private int cardCount = 4;
    private Queue<GameObject> cardPile = new Queue<GameObject>();
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

        SetCardPositions();
        mostRecentCard = cardToPlay;
    }

    public void SetMostRecentCard(GameObject card)
    {
        mostRecentCard = card;
    }

    public void SetCardPositions()
    {
        float yPos = 0.5f;
        float randRotation = 0f;
        Vector3 baseSpot = new Vector3(0f, yPos, 0f);
        foreach (GameObject card in cardPile)
        {
            randRotation = Random.Range(-15f, 15f);
            card.transform.position = baseSpot;
            card.transform.rotation = Quaternion.Euler(90f, 0f, randRotation);
            baseSpot.y += 0.02f;
        }
    }
}
