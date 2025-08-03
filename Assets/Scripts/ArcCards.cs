using System;
using System.Collections;
using System.Runtime.CompilerServices;
using NUnit.Framework.Internal;
using UnityEngine;

public class ArcCards : MonoBehaviour
{
    public float handWidth; // Width of the hand in question
    public Transform leftAnchor; // Left hand anchor
    public Transform rightAnchor; // Right hand anchor 0.55
    public float anchorOffset; // Anchor offset when the hand grows or shrinks
    public float zOffset; // z offset to let cards position behind one another
    private Vector3 originalLAnchorPos; // Original position of the left anchor
    private Vector3 originalRAnchorPos; // Original position of the right anchor
    private int lastCardCount;
    public CardSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastCardCount = -1;
        zOffset = 0.01f; // Set z offset
        anchorOffset = 0.15f; // Set anchor offset
        originalLAnchorPos = leftAnchor.position; // Set original left and right anchor positions
        originalRAnchorPos = rightAnchor.position;
    }

    // Update is called once per frame
    void Update()
    {
        int cardCount = transform.childCount;
        // && (cardCount != lastCardCount)
        if (!spawner.animating)
        {
            SpaceCards();
        }
    }


    void SpaceCards()
    {
        int cardCount = transform.childCount; // Get the amount of children in the player's hand (cards)
        if (cardCount == 0) return; // No need to run this if we have no cards

        OffsetAnchors(cardCount); // Function to offset anchors according to card count
        
        for (int i = 0; i < cardCount; i++) // For every card
        {
            Transform card = transform.GetChild(i);
            float t = (float)i / Mathf.Max(1, cardCount - 1); // The 't' in lerp is equal to i/cardcount - 1

            Vector3 pos = Vector3.Lerp(leftAnchor.position, rightAnchor.position, t); // Get position between anchorpoints
            pos = new Vector3(pos.x, leftAnchor.position.y, leftAnchor.position.z); // Ensure the Y and Z axis are the same for all cards
            pos.z += zOffset; // Modify the z position to be behind the previous card
            zOffset += 0.01f; // Increase z offset for the next card
            card.localPosition = pos; // Locally position the card within the playerhand object
        }

        zOffset = 0.01f; // Reset z offset so cards are not eternally going behind one another
    }

    void OffsetAnchors(int cardCount)
    {
        Vector3 newLPos = originalLAnchorPos; // Create vector for original anchor positions
        Vector3 newRPos = originalRAnchorPos;

        newLPos.x -= anchorOffset * cardCount; // Set the new X positions to be the offset * the card count
        newRPos.x += anchorOffset * cardCount;

        leftAnchor.position = newLPos; // Set our anchors to these new positions
        rightAnchor.position = newRPos;
    }

}
