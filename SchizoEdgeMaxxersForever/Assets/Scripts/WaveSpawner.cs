using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;
    }

    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnLocation;
    public int waveDuration = 60;
    public int maxWaves = 6;
    public int currWave = 0;

    public TextMeshProUGUI waveText;

    private int waveValue;
    private float spawnInterval;
    private float spawnTimer;
    private float waveCooldownTimer = 5f;
    private bool waveInProgress = false;

    public GameObject victoryScreen;

    public GameObject restartButton;

    void Start()
    {
        currWave = 0;
        GenerateWave();
    }

    void Update()
    {
        if (currWave >= 6 && GameObject.FindObjectsOfType<EnemyAi>().Length == 0)
        {
            ShowVictoryScreen();
        }
    }
    void FixedUpdate()
    {
        if (waveInProgress)
        {
            if (enemiesToSpawn.Count > 0)
            {
                if (spawnTimer <= 0)
                {
                    Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
                    enemiesToSpawn.RemoveAt(0);
                    spawnTimer = spawnInterval;
                }
                else
                {
                    spawnTimer -= Time.fixedDeltaTime;
                }
            }
            else
            {
                waveInProgress = false;
                waveCooldownTimer = 5f;
            }
        }
        else if (currWave < maxWaves)
        {
            waveCooldownTimer -= Time.fixedDeltaTime;

            if (waveCooldownTimer <= 0)
            {
                GenerateWave();
            }
        }
    }

    public void GenerateWave()
    {
        currWave++;
        Debug.Log("Spawning Wave: " + currWave);

        if (waveText != null)
            waveText.text = "Wave " + currWave;

        waveValue = Mathf.Max(currWave * 5, 1);
        GenerateEnemies();

        if (enemiesToSpawn.Count == 0)
        {
            Debug.LogWarning("No enemies generated for wave " + currWave);
            return;
        }

        spawnInterval = (float)waveDuration / enemiesToSpawn.Count;
        spawnTimer = 0;
        waveInProgress = true;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        int remainingValue = waveValue;

        while (remainingValue > 0)
        {
            List<Enemy> affordableEnemies = enemies.FindAll(e => e.cost <= remainingValue);

            if (affordableEnemies.Count == 0)
                break;

            Enemy chosen = affordableEnemies[Random.Range(0, affordableEnemies.Count)];
            generatedEnemies.Add(chosen.enemyPrefab);
            remainingValue -= chosen.cost;
        }

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f; // pause the game
        restartButton.SetActive(true);
    }
}