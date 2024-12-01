using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject shield;

    public float shieldPower = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shield = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Shield"))
        {
            shieldPower -= 10;
        }

    }
}
