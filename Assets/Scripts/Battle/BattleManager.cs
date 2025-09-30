using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    Battler player;
    Battler enemy;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        instance = this;
    }

    public void StartBattle(GameObject _player, GameObject _enemy)
    {
        //fix pra usar TryGetComponent qnd eu tver saco pra consertar isso
        player = _player.GetComponent<Battler>();
        enemy = _enemy.GetComponent<Battler>(); 

        if(player == null || enemy == null)
        {
            return;
            Debug.Log("The battle failed because one of the provided objects wasn't a Battler");
        }

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
