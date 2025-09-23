using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    [SerializeField] int HPMax;
    [SerializeField] int HPCurr;
    [SerializeField] int atk;
    [SerializeField] int def;
    [SerializeField] int spd;

    public bool isAlive;

    public int GetHealth() { return HPCurr; }
    public int GetAttack() { return atk; }
    public int GetDefense() { return def; }
    public int GetSpeed() { return spd; }

    public void TakeDamage(int dmg)
    {
        HPCurr -= dmg;
        if(HPCurr <= 0) 
        {
            HPCurr = 0;
            isAlive = false;
        }
        if(HPCurr > HPMax)
        {
            HPCurr = HPMax;
        }
    }
}
