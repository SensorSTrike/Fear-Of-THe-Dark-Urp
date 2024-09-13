using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab; // Mit‰ spawnataan 

    [SerializeField]
    private float _minimumSpawnTime; // Minimi ja 

    [SerializeField]
    private float _maximumSpawnTime; // Maksimi ajat spawnaamiselle 

    [SerializeField]
    private float spawnAreaWidth = 10f; 

    [SerializeField]
    private float spawnAreaHeight = 10f; 

    private float _timeUntilSpawn; // Aikaa seuraavaan spawniin (tehd‰‰n sille metodi joka asettaa arvon) 

    void Awake() // Kutsutaan spawnausaikametodia kun skene alkaa 
    {
        SetTimeUntilSpawn();
    }

        void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            SpawnEnemy();
            SetTimeUntilSpawn();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2),
            Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2)
            );

        Instantiate(_enemyPrefab, transform.position + (Vector3)spawnPosition, Quaternion.identity);
    }

private void SetTimeUntilSpawn() // Arvotaan spawnausaika 
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime); // Randomilla minimin ja maksimin v‰lill‰ 
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaWidth, spawnAreaHeight, 1));
    }   //Hyv‰ Artiiiiii!
}     
