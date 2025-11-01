using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnOption
{
    public SpeciesBase species;
    public int minLevel;
    public int maxLevel;

    public GameObject GenerateMonster()
    {
        //só pra n dar erroe nquanto não ajeito
        return null;
    }
}

public class RandomEncounter : MonoBehaviour
{
    //SHOULD BE MOVED TO SINGLETON
    [SerializeField] SerializableDictionary<SpawnOption, float> encounterTable;

    [SerializeField] float encounterChance;

    //chance de um trigger pra batalha quando o player colide com o objeto de spawn
    private void OnTriggerEnter(Collider other)
    {
        if(Random.Range(0,100) < encounterChance)
        {
            Debug.Log("Got an encounter");
            //gerando o encounter escolhido randomicamente do dicionário e checando se ele é válido para uso
            GameObject generatedEnemy = GenerateEncounter();
            MonsterBehaviour mb = generatedEnemy.GetComponent<MonsterBehaviour>();
            if (mb == null)
            {
                Debug.LogError("Generated monster missing MonsterBehaviour!");
                return;
            }

            //salvando os inimigos para uso na próxima cena
            GameManager.instance.LoadEnemies(new List<MonsterData> { mb.Data });

            BattleManager.instance.StartBattle();
        }
    }

    GameObject GenerateEncounter()
    {
        float total = 0;
        foreach (float chance in encounterTable.GetValues())
        {
            total += chance;
        }
        float roll = Random.Range(0, total);

        float cumulative = 0;
        foreach (var kvp in encounterTable.GetDictionary())
        {
            cumulative += kvp.Value;
            if (roll < cumulative)
            {
                return kvp.Key.GenerateMonster();
            }
        }

        return null;
    }

    void StartBattle()
    {

    }
}
