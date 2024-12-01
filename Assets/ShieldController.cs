using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public float shieldPower=100;
    void Start()
    {
        
    }

    // Update is called once per framess
    void Update()
    {
        if(shieldPower <= 50)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            shieldPower -= 10;
        }
    }
}
