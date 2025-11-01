using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    Battler player;
    Battler enemy;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        instance = this;
    }

    public void StartBattle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");

        GameObject playerPos = GameObject.FindGameObjectWithTag("Player Team");
        GameObject enemyPos = GameObject.FindGameObjectWithTag("Enemy Team");

        Transform deployPlayer;
        Transform deployEnemy;

        for(int i = 0; i < 3; ++i)
        {
            deployPlayer = playerPos.transform.GetChild(i);
            deployEnemy = enemyPos.transform.GetChild(i);
            if (GameManager.instance.party[i] != null)
                Instantiate(GameManager.instance.party[i].baseData.prefab, deployPlayer.position, deployPlayer.rotation);
            if (GameManager.instance.currentEnemies[i] != null)
                Instantiate(GameManager.instance.party[i].baseData.prefab, deployEnemy.position, deployEnemy.rotation);
        }

        //Batalha real (pode ser movido para outro método
        /*
        //fix pra usar TryGetComponent qnd eu tver saco pra consertar isso
        player = _player.GetComponent<Battler>();
        enemy = _enemy.GetComponent<Battler>(); 

        if(player == null || enemy == null)
        {
            Debug.Log("The battle failed because one of the provided objects wasn't a Battler");
            return;
        }

        if (player.GetSpeed() > enemy.GetSpeed())
            StartTurn(player, enemy);
        else if (player.GetSpeed() == enemy.GetSpeed())
        {
            if (Random.Range(0, 1) >= 0.5)
                StartTurn(player, enemy);
            else
                StartTurn(enemy, player); //talvez seja bom trocar por um método diferente porque aqui deve ser usada a AI do inimigo, enquanto o StartTurn do player é 100% input
        }
        else
            StartTurn(enemy, player);
        */
    }

    void StartTurn(Battler current, Battler opponent)
    {
        //Sistema de combate mais básico possível (possivelmente temporário): oponentes trocam ataques até que um dos dois morra
        opponent.TakeDamage(current.Data.attack);
        if (!opponent.isAlive)
            EndBattle(current);
        //Selecionar entre atacar, defender/esquivar ou usar item
    }

    void EndBattle(Battler winner)
    {
        if (winner == enemy)
        {
            //Game over logic
        }
        else //if (winner == player)
        {
            //Battle win logic
        }
    }
}
