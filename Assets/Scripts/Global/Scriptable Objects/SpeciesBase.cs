using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeciesBase", menuName = "Monsters/Species Base")]
public class SpeciesBase : ScriptableObject
{
    [Header("Identity")]
    public string id;
    public string displayName;
    public Kingdom kingdom;
    public Sprite icon;
    public GameObject prefab; // usado pra spawnar o objeto

    [Header("Base Stats")]
    public int baseHP;
    public int baseAttack;
    public int baseDefense;
    public int baseSpeed;

    [Header("Evolution")]
    public List<EvolutionCondition> evolutions;
}

public class EvolutionCondition
{

}

public enum Kingdom
{
    Magic,
    Science,
    Nature,
    Chimera
}
