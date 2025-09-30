using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounter : MonoBehaviour
{
    [SerializeField] SerializableDictionary<GameObject, float> encounterTable;
    [SerializeField] float encounterChance;

    private void OnTriggerEnter(Collider other)
    {
        if(Random.Range(0,100) < encounterChance)
        {
            //BattleManager.instance.StartBattle();
        }
    }
}
