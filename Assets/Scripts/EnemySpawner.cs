using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Düþman prefabý
    public float spawnRate = 2f; // Düþman doðma süresi (saniye)
    public float spawnRange = 5f; // Spawn noktasýndan uzaklýk (yarýçap)
    public float spawnDistance = 10f; // Sahne dýþýnda doðma mesafesi
    public Transform spawnArea; // Spawn noktasý (boþ GameObject)

    private Transform player;

    public int maxEnemies = 6; // Maksimum düþman sayýsý

    private int currentEnemyCount = 0; // Sahnedeki mevcut düþman sayýsý

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncuyu bul
        InvokeRepeating("SpawnEnemy", 1f, spawnRate); // Düþmanlarý tekrar tekrar doður

    }

    void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy çaðrýldý!"); // Kontrol için
        // Eðer sahnede maksimum düþman varsa yeni düþman oluþturma
        if (currentEnemyCount >= maxEnemies)
        {
            return;
        }

        // Rastgele bir açý belirle
        float angle = Random.Range(0f, 360f);

        

        //Vector3 spawnPosition = player.position + (Quaternion.Euler(0, 0, angle) * Vector3.up) * spawnDistance;

        // Rastgele bir pozisyon hesapla (spawnArea pozisyonuna göre)
        Vector2 randomOffset = Random.insideUnitCircle * spawnRange;
        Vector3 spawnPosition = spawnArea.position + new Vector3(randomOffset.x, randomOffset.y, 0);

        // Düþmaný oluþtur
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition,transform.rotation);
        Debug.Log("Düþman oluþturuldu: " + enemy.name);

        // Düþman sayýsýný artýr
        currentEnemyCount++;

        // Düþman yok edildiðinde düþman sayýsýný azalt
        enemy.GetComponent<EnemyController>().onEnemyDestroyed += () => currentEnemyCount--;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
