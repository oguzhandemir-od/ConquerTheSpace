using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // D��man prefab�
    public float spawnRate = 2f; // D��man do�ma s�resi (saniye)
    public float spawnRange = 5f; // Spawn noktas�ndan uzakl�k (yar��ap)
    public float spawnDistance = 10f; // Sahne d���nda do�ma mesafesi
    public Transform spawnArea; // Spawn noktas� (bo� GameObject)

    private Transform player;

    public int maxEnemies = 6; // Maksimum d��man say�s�

    private int currentEnemyCount = 0; // Sahnedeki mevcut d��man say�s�

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncuyu bul
        InvokeRepeating("SpawnEnemy", 1f, spawnRate); // D��manlar� tekrar tekrar do�ur

    }

    void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy �a�r�ld�!"); // Kontrol i�in
        // E�er sahnede maksimum d��man varsa yeni d��man olu�turma
        if (currentEnemyCount >= maxEnemies)
        {
            return;
        }

        // Rastgele bir a�� belirle
        float angle = Random.Range(0f, 360f);

        

        //Vector3 spawnPosition = player.position + (Quaternion.Euler(0, 0, angle) * Vector3.up) * spawnDistance;

        // Rastgele bir pozisyon hesapla (spawnArea pozisyonuna g�re)
        Vector2 randomOffset = Random.insideUnitCircle * spawnRange;
        Vector3 spawnPosition = spawnArea.position + new Vector3(randomOffset.x, randomOffset.y, 0);

        // D��man� olu�tur
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition,transform.rotation);
        Debug.Log("D��man olu�turuldu: " + enemy.name);

        // D��man say�s�n� art�r
        currentEnemyCount++;

        // D��man yok edildi�inde d��man say�s�n� azalt
        enemy.GetComponent<EnemyController>().onEnemyDestroyed += () => currentEnemyCount--;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
