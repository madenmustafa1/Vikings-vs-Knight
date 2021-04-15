using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceObject : MonoBehaviour
{
    public Transform transform;

    public GameObject player;
    void Start()
    {
        Instantiate(player, transform.transform.position, Quaternion.identity);

               
    }

    void Update()
    {
        
    }
}
