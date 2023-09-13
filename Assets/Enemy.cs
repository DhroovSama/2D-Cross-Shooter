using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Vector3 movementDirection;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = movementDirection * speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.GetComponent<Bullet>() != null)
        {
            Destroy(this.gameObject);
            Destroy(c.gameObject);
        }

        if (c.gameObject.GetComponent<PlayerLogic>() != null)
        { 
            Destroy(c.gameObject);
        }
    }
}
