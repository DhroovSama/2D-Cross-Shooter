using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 movementDirection;
    public float speed;
    
    public float lifeTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = movementDirection * speed;

        lifeTime -= Time.deltaTime;
        if(lifeTime <=0){
            Destroy(this.gameObject);
        }
    }
}
