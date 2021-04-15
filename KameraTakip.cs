using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    [SerializeField]

    GameObject player;
    Vector3 aradakifark;


    // Use this for initialization
    void Start()
    {
        aradakifark = transform.position - player.transform.position;

        //aradaki farkı buluyoruz
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + aradakifark;
    }
}
