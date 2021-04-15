using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{
    HealthBar healthBar;
    public float can2;

    public static float canEkslit = -5f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(cagir());
        }
    }


    public IEnumerator cagir()
    {
        HealthBar.can -= 20;
        yield return new WaitForSeconds(1f);
    }
}
