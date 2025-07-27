using UnityEngine;

// Create enums to represent pre-determined otions for color and type
    public enum CardColor { Red, Blue, Yellow, Green, Wild };
    public enum CardType { Number, Wild, Reverse, Skip, DrawTwo };


// Code that will allow me to choose this object to create from the asset menu
[CreateAssetMenu(fileName = "NewCardData", menuName = "CardGame/CardData")]

public class CardData : ScriptableObject
{
    // Stores color of the card
    public CardColor color;

    // Stores type of card
    public CardType type;

    // Stores number for number-type cards only
    public int number;

}
