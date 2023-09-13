using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject bulletPrefab;
    public float shootingCooldown;
    private float shootingTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 worldPosition = gameCamera.ScreenToWorldPoint(mousePosition);

        this.transform.position = new Vector3(worldPosition.x, worldPosition.y, this.transform.position.z); 

        shootingTimer -= Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && shootingTimer <= 0)
        {

            shootingTimer = shootingCooldown;

            Vector2[] directions = new Vector2[]
            {
                Vector2.up,
                Vector2.down,
                Vector2.right,
                Vector2.left
            };

            foreach (Vector2 direction in directions)
            {
                GameObject bulletObject = Instantiate(bulletPrefab);
                bulletObject.transform.position = this.transform.position;
                Bullet bullet = bulletObject.GetComponent<Bullet>();
                bullet.movementDirection = direction;
            }

            
        }
    }
}
