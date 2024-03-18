using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab;
    public int minCircles = 5;
    public int maxCircles = 10;
    public Vector2 spawnArea;

    [SerializeField] private Transform spawnParent;
    [SerializeField] private Button restartButton;

    void Start()
    {
        SpawnCircles();
        restartButton.onClick.AddListener(RestartScene);
    }

    void SpawnCircles()
    {
        int numCircles = Random.Range(minCircles, maxCircles + 1);

        for (int i = 0; i < numCircles; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y));
            spawnPos.x += 200f;
            spawnPos.y += 200f;
            Instantiate(circlePrefab, spawnPos, Quaternion.identity, spawnParent);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
