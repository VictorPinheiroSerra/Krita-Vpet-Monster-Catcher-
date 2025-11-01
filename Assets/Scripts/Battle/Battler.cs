using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Battler : MonsterBehaviour
{
    public bool isAlive;
    public void TakeDamage(int dmg)
    {
        Data.currentHP -= dmg;
        if(Data.currentHP <= 0) 
        {
            Data.currentHP = 0;
            isAlive = false;
        }
        if(Data.currentHP > Data.maxHP)
        {
            Data.currentHP = Data.maxHP;
        }
    }
}
