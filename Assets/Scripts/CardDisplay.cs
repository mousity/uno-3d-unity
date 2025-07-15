using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    public CardData cardData;
    // Serialize is used to publicize private or protected fields into the unity editor
    [SerializeField] private TextMeshPro textComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ApplyCardData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ApplyCardData()
    {
        if (cardData == null)
        {
            return;
        }

        // Get renderer component for easy modifications
        Renderer rend = GetComponent<Renderer>();

        // If the card type is a number
        if (cardData.type.ToString() == "Number")
        {
            textComponent.text = cardData.number.ToString(); // Set the text component to be the number
        }
        else
        {
            textComponent.text = cardData.type.ToString(); // Otherwise, set the text to be the type
        }


        // If statements to change the color according to the color in CardData
        if (cardData.color.ToString() == "Red")
        {
            rend.material.color = Color.red;
        }
        else if (cardData.color.ToString() == "Blue")
        {
            rend.material.color = Color.blue;
        }
        else if (cardData.color.ToString() == "Yellow")
        {
            rend.material.color = Color.yellow;
        }
        else if (cardData.color.ToString() == "Green")
        {
            rend.material.color = Color.green;
        }
    }

    public void SetCardData(CardData card)
    {
        cardData = card;
    }
}
