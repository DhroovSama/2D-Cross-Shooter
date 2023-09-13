using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public PlayerLogic player;
    public Text gameText; 
    public GameObject enemyPrefab;
    public float enemyCountdown = 2f;
    private float enemyTimer;
    private float gameTimer;
    public float minimumEnemyCountdown = 1f;
    private bool isGameOver = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (player != null)
        {
            gameTimer += Time.deltaTime;
            gameText.text = "Time: " + Mathf.Floor(gameTimer);
        } else{
            if(!isGameOver){
                isGameOver = true;

                gameText.text += "\nGame Over, Press R to restart!";
            }
        }
        enemyTimer -= Time.deltaTime;
        if (enemyTimer <= 0 && player != null)
        {
            enemyTimer = enemyCountdown;

            enemyCountdown *= 0.9f;

            if (enemyCountdown < minimumEnemyCountdown)
            {
                enemyCountdown = minimumEnemyCountdown;
            }

            Vector3[] spawnPositions = new Vector3[]
            {
                new Vector3(11,5,0),
                new Vector3(11,-5,0),
                new Vector3(-11,5,0),
                new Vector3(-11,-5,0),
            };

            foreach(Vector3 spawnPosition in spawnPositions)
            {
                GameObject enemyObject = Instantiate (enemyPrefab);
                enemyObject.transform.position = spawnPosition; 
                enemyObject.transform.SetParent(this.transform);

                Enemy enemy = enemyObject.GetComponent<Enemy>();
                enemy.movementDirection = (player.transform.position - spawnPosition).normalized; 
            }
        }        
    }
}
