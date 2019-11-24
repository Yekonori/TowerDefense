using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    public Text waveCountdownText;

    private float _countdown = 2f;
    private int _waveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            SpawnWave();
            _countdown = timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Floor(_countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++;

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
