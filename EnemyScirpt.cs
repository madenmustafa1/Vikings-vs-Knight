using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScirpt : MonoBehaviour
{

    public float speed;
    public float stopDistance;

    private Transform target;

    public AnimationClip _walk, _jump;
    public Animation _Legs;

    SpriteRenderer spriteRenderer;

    HealthBar healthBar;

    public static int health = 4;
 
    private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        if(Vector2.Distance(transform.position,target.position)< stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            _Legs.clip = _walk;
            _Legs.Play();


            //transform.rotation = Quaternion.Euler(0, 180, 0);
            if (target.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
 
    }
}
