using UnityEngine;

public class ScaleHover : MonoBehaviour
{

    // Variables to keep original card scale, new scale, and check if the card is already hovered
    private Vector3 originalScale;
    private Vector3 newScale;
    private bool isHovered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isHovered = false;
        originalScale = transform.localScale;
        newScale = new Vector3(0.1f, 0.1f, 0f);
        newScale += originalScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHoverEnter() // When we enter a card
    {
        if (isHovered) return; // If it's already hovered, return
        transform.localScale = newScale; // Change the scale
        isHovered = true; // Set the hover to true
    }

    public void OnHoverExit() // When we exit a card
    {
        if (!isHovered) return; // If it's not hovered anymore, return
        transform.localScale = originalScale; // Change the card scale to the original
        isHovered = false; // Set the hover to false
    } 
}
