using UnityEngine;

public class ArcCards : MonoBehaviour
{
    public float handWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handWidth = 4;
        SpaceCards();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpaceCards()
    {
        int cardCount = transform.childCount;
        if (cardCount == 0) return;


    }
}
