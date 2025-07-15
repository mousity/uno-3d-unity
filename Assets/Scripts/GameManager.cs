using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardSpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner.DrawRandomCard();
    }

}
