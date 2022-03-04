using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject easyBug;

    IEnumerator Start() //this tells system to wait until certain
    {
        //wave1
        yield return new WaitForSeconds(1);
        
        for(int i=0; i<20; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-8f, 7f), transform.position.y + Random.Range(0, 8f));
            Instantiate(easyBug, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }


        yield return new WaitForSeconds(10);
        for (int i = 0; i < 50; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-8f, 7f), transform.position.y + Random.Range(0, 8f));
            Instantiate(easyBug, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }

    }

    
}
