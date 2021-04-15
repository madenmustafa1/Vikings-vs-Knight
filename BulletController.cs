using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 speed;
    public float wait = 4f;

    private Rigidbody2D rigid;

    EnemySpawner enemySpawner;

 
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigid.velocity = speed;

        StartCoroutine("Delete");

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyScirpt.health -= 1;
            if(EnemyScirpt.health <= 0)
            {
                
                Destroy(other.gameObject);
                EnemyScirpt.health = 5;
                HealthBar.can += 30;
                //enemySpawner.getObject();
            }
            Destroy(gameObject);

        }
        else if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            //AudioSource.PlayClipAtPoint(deadSound2, other.gameObject.transform.position);
        }
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(wait);
        Destroy(gameObject);
    }
}
