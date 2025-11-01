using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<MonsterData> party;
    public List<MonsterData> currentEnemies;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //recebe os inimigos do objeto de spawn e armazena eles pra usar na Cena de batalha
    public void LoadEnemies(List<MonsterData> enemies)
    {
        currentEnemies = enemies;
    }
}
