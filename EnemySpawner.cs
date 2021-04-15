using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public int number = 1;
    void Start()
    {
        
    }

    
    void Update()
    {
        //StartCoroutine("getObject");
        GameObject gameObject = GameObject.FindGameObjectWithTag("Enemy");
        if (!gameObject)
        {
            if(number == 1)
            {
                getObject();
                gameObject = GameObject.FindGameObjectWithTag("Enemy");
            }
        }
    }

    public void getObject()
    {
        StartCoroutine("getObjectSpawn");
    }

    IEnumerator getObjectSpawn()
    {
        number = 0;
        yield return new WaitForSeconds(1.5f);
        Instantiate(Enemy, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        number = 1;

    }
}
