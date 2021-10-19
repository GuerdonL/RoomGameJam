using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyRoomOnEnter : MonoBehaviour
{
    public bool defeated = false;
    public Collider2D spawnableArea;
    public GameObject red;
    public GameObject blue;
    public List<Enemy> enemies;
    [System.Serializable]
    public struct Enemy {
        public int enemyNumber;
        public GameObject enemyPrefab;
    }
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private bool spawned = false;
    private void Start() {
        red.SetActive(false);
        blue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //check is it's the player, and whether the room has already been started or even finished
        if(other.CompareTag("Player")&&!red.activeSelf&&!blue.activeSelf){
            blue.SetActive(true);
            foreach (Enemy en in enemies){
                for(int i = 0; i < en.enemyNumber; i++){
                    Vector3 randPos = new Vector3(Random.Range(spawnableArea.bounds.min.x, spawnableArea.bounds.max.x), Random.Range(spawnableArea.bounds.min.y, spawnableArea.bounds.max.y), 0);
                    GameObject spawnedEnemy = (GameObject) Instantiate(en.enemyPrefab, randPos, Quaternion.identity);
                    //spawnedEnemy.transform.parent = gameObject.transform;
                    spawnedEnemies.Add(spawnedEnemy);
                    spawned = true;
                }
            }
        }
    }

    private void Update(){
        if(spawned){
            foreach(GameObject en in spawnedEnemies){
                try{if(!en.activeSelf){
                    spawnedEnemies.Remove(en);
                }}
                catch{spawnedEnemies.Remove(en);}
            }
            if(spawnedEnemies.Count==0){
                blue.SetActive(false);
                red.SetActive(true);            
                defeated = true;
            }
        }
    }
}
