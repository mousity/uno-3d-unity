using System;
using UnityEngine;

public class ArcCards : MonoBehaviour
{
    public float handWidth;
    public Transform leftAnchor;
    public Transform rightAnchor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

        for (int i = 0; i < cardCount; i++)
        {
            float t = (float)i / cardCount;

            Vector3 pos = Vector3.Lerp(leftAnchor.position, rightAnchor.position, t);
            pos = new Vector3(pos.x, leftAnchor.position.y, leftAnchor.position.z);
            Debug.Log("hi");
            Debug.Log(pos.ToString());

            transform.GetChild(i).localPosition = pos;
        }
        

    }
}
