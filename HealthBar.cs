using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject canBar;
    public static float can;

    BladeScript bladeScript;

    PlayerMove playerMove;

    public GameObject player;

    public static bool kontrol = true;

    void Start()
    {
        can = 100;
    }

    void Update()
    {
        transform.position = player.transform.position;
        canBar.transform.localScale = new Vector3(can/20, 4, 2);
        if(can >= 100)
        {
            can = 100;
        }
        if(can <= 0)
        {
            can = 0;
            //playerMove.PlayerDead();
            kontrol = false;
        }
        //can = bladeScript.can
    }
}
