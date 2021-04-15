using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPosRot : MonoBehaviour
{

    public AudioClip audioClip;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        EnemyScirpt.health -= 1;
        if(EnemyScirpt.health <= 0)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                EnemyScirpt.health = 5;
                HealthBar.can += 30;
            }
        }
    }
}
