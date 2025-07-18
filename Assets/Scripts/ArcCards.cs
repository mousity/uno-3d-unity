using System;
using UnityEngine;

public class ArcCards : MonoBehaviour
{
    public float handWidth;
    public Transform leftAnchor; // Left hand anchor
    public Transform rightAnchor; // Right hand anchor
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpaceCards();
    }

    // Update is called once per frame
    void Update()
    {
        SpaceCards();
    }

    void SpaceCards()
    {
        int cardCount = transform.childCount; // Get the amount of children in the player's hand (cards)
        if (cardCount == 0) return; // No need to run this if we have no cards

        for (int i = 0; i < cardCount; i++) // For every card
        {
            float t = (float)i / Mathf.Max(1, cardCount - 1); // The 't' in lerp is equal to i/cardcount - 1

            Vector3 pos = Vector3.Lerp(leftAnchor.position, rightAnchor.position, t); // Get position between anchorpoints
            pos = new Vector3(pos.x, leftAnchor.position.y, leftAnchor.position.z); // Ensure the Y and Z axis are the same for all cards
            Debug.Log("hi");
            Debug.Log(pos.ToString());

            transform.GetChild(i).localPosition = pos; // Locally position the card within the playerhand object
        }
        

    }
}
