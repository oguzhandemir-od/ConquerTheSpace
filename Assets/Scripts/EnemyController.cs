using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // D��man hareket h�z�
    public GameObject bulletPrefab; // Mermi prefab�
    public Transform bulletSpawnPoint; // Merminin ��k�� noktas�
    public float bulletSpeed = 8f; // Mermi h�z�
    public float fireRate = 2f; // Ate� etme aral���
    public delegate void EnemyDestroyed(); // Olay tipi
    public event EnemyDestroyed onEnemyDestroyed; // D��man yok edildi�inde tetiklenecek olay

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncuyu bul
        InvokeRepeating("Fire", 1f, fireRate); // Belirli aral�klarla ate� et
    }

    // Update is called once per frame
    void Update()
    {
        // Oyuncuya do�ru hareket
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
    void Fire()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null && player != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (player.position - bulletSpawnPoint.position).normalized;
                rb.velocity = direction * bulletSpeed;
            }

            Destroy(bullet, 5f);
        }
    }

    void OnDestroy()
    {
        // D��man yok edildi�inde olay� tetikle
        if (onEnemyDestroyed != null)
        {
            onEnemyDestroyed.Invoke();
        }
    }
}
