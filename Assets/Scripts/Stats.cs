using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    // Num of hits that can be taken
    public int health = 3;

    // Num of damage each dash deals on enemy
    public int strength = 1;

    // Player Speed
    public float speed = 5f;

    // Dash Cooldown
    public float dashCooldown = 10f;

    //Dash Length
    public float dashTime = 10f;

    // Dash Speed Muiltiplier
    public float DashPower = 10f;

    // Jump Height
    public float jumpPower = 16f;

    public Player() { }
}
