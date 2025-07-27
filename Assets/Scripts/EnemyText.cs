using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.DualShock.LowLevel;

public class EnemyText : MonoBehaviour
{
    public EnemyLines lines;
    private Vector3 bubbleSize;
    private float duration = 0.5f;
    private TextMeshProUGUI messageText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bubbleSize = transform.localScale; // Remember the original scale of the text bubble
        transform.localScale = Vector3.zero; // Set the current scale to 0
        gameObject.SetActive(true);
        messageText = GetComponentInChildren<TextMeshProUGUI>(); // Get our textmesh child (assuming we only have the one)
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Coroutine to scale the bubble up slowly
    public IEnumerator ScaleBubbleUp(GameState state)
    {
        gameObject.SetActive(true); // Set gameobject to active so it shows up
        float t = 0f; // time elapsed
        if (state == GameState.StartGame) // If the game is at the start
        {
            while (t < duration) 
            {
                transform.localScale = Vector3.Lerp(Vector3.zero, bubbleSize, t / duration); // Transform the scale over time
                t += Time.deltaTime;
                yield return null;
            }

            StartCoroutine(TypeText()); // Start the coroutine to type the text into the textmesh
        }
    }

    // Coroutine to set the text slowly in the bubble
    public IEnumerator TypeText()
    {
        int randomIndex = UnityEngine.Random.Range(0, lines.lines.Length); // Get a random index
        string line = lines.lines[randomIndex]; // Grab a random line
        string slowLine = ""; // String to hold the temporary line
        foreach (char letter in line) // For each letter in our line
        {
            slowLine += letter; // Add to the string
            messageText.SetText(slowLine); // Set the text
            yield return new WaitForSeconds(0.03f); // Wait a bit before doing the next letter
        }
    }
}
