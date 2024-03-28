using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshPro scoreText; // Renamed to follow camelCase convention
    public GameObject hazardPrefab;
    public GameObject coinPrefab;
    public GameObject themeboxPrefab;
    public Transform northPoint;
    public Transform southPoint;
    public Transform eastPoint;
    public Transform westPoint;
    [Range(1, 11)] public int coinCount = 5;
    public float coinSpawnDelay = 2;
    float timeElapsed = 0;
    int currentCoinCount = 0;
    public float CoinSpeed;
    public float HazardSpeed;
    private int score = 0; // Track the score
    private void Start()
    {
        UpdateScoreText(); // Update the score text when the game starts
    }

    private void Update()
    {
        if (timeElapsed < coinSpawnDelay)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            SpawnItem();
            timeElapsed = 0;
        }
    }

    public void SpawnItem()
    {
        int randomIndex = Random.Range(0, 3); // Randomly select between 0, 1, and 2

        switch (randomIndex)
        {
            case 0:
                GameObject coin = Instantiate(coinPrefab, SpawnPos(), Quaternion.identity);
                coin.GetComponent<Coin>().coinSpeed = Random.Range(6, 1);
                break;

            case 1:
                GameObject hazard = Instantiate(hazardPrefab, SpawnPos(), Quaternion.identity);
                hazard.GetComponent<HazardMovement>().hazardSpeed = Random.Range(5, 1);
                break;
            case 2:
                GameObject themebox = Instantiate(themeboxPrefab, SpawnPos(), Quaternion.identity);
                themebox.GetComponent<ThemeBox>().themeSpeed = Random.Range(5, 1);
                break;
        }
    }

    private Vector2 SpawnPos()
    {
        float xValue = Random.Range(westPoint.position.x, eastPoint.position.x);
        float yValue = northPoint.position.y;
        Vector2 temp = new Vector2(xValue, yValue);
        return temp;
    }

    // Method to update the score
    public void UpdateScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    // Method to update the score text
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the score text with the current score
    }
}
