using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float moveSpeed = 10f; // Gemi hareket h�z�
    public GameObject bulletPrefab; // Mermi prefab�
    public Transform bulletSpawnPoint; // Merminin ��k�� noktas�
    public float bulletSpeed = 20f; // Mermi h�z�

    public GameObject shield;
    public GameObject enemyBullet;
    public float shieldPower = 100f;
    public float health=100;

    void Update()
    {
        // Hareket kontrol�
        float horizontal = Input.GetAxis("Horizontal"); // Sa�-Sol
        float vertical = Input.GetAxis("Vertical"); // Yukar�-A�a��

        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Ate� etme
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        if(shieldPower<50)
        {
            shield.SetActive(false);
        }
    }

    void Fire()
    {
        // Mermiyi olu�tur
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Mermiye ileri do�ru h�z ver
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * bulletSpeed; // Yukar� do�ru hareket
        }

        Destroy(bullet, 5f);
    }

    // �arp��ma tespiti (OnCollisionEnter2D)
    
}
