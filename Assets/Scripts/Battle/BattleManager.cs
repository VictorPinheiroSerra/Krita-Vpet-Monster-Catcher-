using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    Battler player;
    Battler enemy;

    public void StartBattle(Battler _player, Battler _enemy)
    {
        player = _player;
        enemy = _enemy;

        if (!player.isAlive)
        {
            //Game over logic
        }
        if (!enemy.isAlive)
        {
            //Battle win logic
        }

        if (player.GetSpeed() > enemy.GetSpeed())
            StartTurn(player);
        else if (player.GetSpeed() == enemy.GetSpeed())
        {
            if (Random.Range(0, 1) >= 0.5)
                StartTurn(player);
            else
                StartTurn(enemy);
        }
        else
            StartTurn(enemy);
    }

    void StartTurn(Battler current)
    {

    }
}
