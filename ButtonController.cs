using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonController : MonoBehaviour
{
    PlayerMove player;

    void Start()
    {    
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();      
    }
  
    public void AttackButton()
    {
        player.AttackPlayerMobile();
    }
    public void LeftButton()
    {
          player.MoveLeftMobile();     
    }
    public void RightButton()
    {
        player.MoveRightMobile();

    }
    public void StopButton()
    {
        player.StopPlayerMobile();
    }
    public void JumpButton()
    {
        player.JumpPlayerMobile();
    }
    public void FireButton()
    {
        player.MobileFireBullet();
    }
}