using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.DualShock.LowLevel;

public class EnemyText : MonoBehaviour
{
    private Vector3 bubbleSize;
    private float duration = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ;
        bubbleSize = transform.localScale; // Remember the original scale of the text bubble
        transform.localScale = Vector3.zero; // Set the current scale to 0
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Coroutine to scale the bubble up slowly
    public IEnumerator ScaleBubbleUp(GameState state)
    {
        gameObject.SetActive(true);
        float t = 0f; // time elapsed
        if (state == GameState.StartGame)
        {
            while (t < duration)
            {
                transform.localScale = Vector3.Lerp(Vector3.zero, bubbleSize, t / duration);
                t += Time.deltaTime;
                yield return null;
            }
        }
    }
}
