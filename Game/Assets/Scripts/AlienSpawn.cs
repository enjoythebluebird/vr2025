using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class AlienSpawn : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 20)
        {
            xPos = Random.Range(-16, 13);
            zPos = Random.Range(-20, 1);
            Instantiate(theEnemy, new Vector3(xPos, -4, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5);
            EnemyCount += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
