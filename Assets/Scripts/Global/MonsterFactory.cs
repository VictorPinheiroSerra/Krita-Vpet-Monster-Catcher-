using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    public static GameObject CreateMonsterInstance(SpeciesBase species, int level)
    {
        if (species == null || species.prefab == null)
        {
            Debug.LogError("Cannot create monster: species or prefab is null.");
            return null;
        }

        MonsterData data = MonsterData.Create(species, level);

        GameObject obj = Instantiate(species.prefab);
        MonsterBehaviour behaviour = obj.GetComponent<MonsterBehaviour>();

        if (behaviour != null)
            behaviour.Initialize(data);
        else
            Debug.LogWarning($"Prefab {species.prefab.name} has no MonsterBehaviour attached!");

        return obj;
    }
}
