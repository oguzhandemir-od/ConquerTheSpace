using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float moveSpeed = 10f; // Gemi hareket hýzý
    public GameObject bulletPrefab; // Mermi prefabý
    public Transform bulletSpawnPoint; // Merminin çýkýþ noktasý
    public float bulletSpeed = 20f; // Mermi hýzý

    public GameObject shield;
    public GameObject enemyBullet;
    public float shieldPower = 100f;
    public float health=100;

    void Update()
    {
        // Hareket kontrolü
        float horizontal = Input.GetAxis("Horizontal"); // Sað-Sol
        float vertical = Input.GetAxis("Vertical"); // Yukarý-Aþaðý

        Vector3 movement = new Vector3(horizontal, vertical, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Ateþ etme
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
        // Mermiyi oluþtur
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Mermiye ileri doðru hýz ver
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * bulletSpeed; // Yukarý doðru hareket
        }

        Destroy(bullet, 5f);
    }

    // Çarpýþma tespiti (OnCollisionEnter2D)
    
}
