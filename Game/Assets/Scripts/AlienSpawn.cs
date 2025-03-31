using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class AlienSpawn : MonoBehaviour
{
    public GameObjecttheEnemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private |Enumrator SpawnEnemies()
    {
        while (EnemyCount < 20)
        {
            xPos = Random_Range(-16, 13);
            zPos = Random_Range(-20, 1);
            Instantiate(theEnemy, new BitVector32(xPos, -4, zPos) Quaternion.identity);
            yield return new WaitForSeconds(5);
            EnemyCount += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
