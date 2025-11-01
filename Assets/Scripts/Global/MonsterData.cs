using UnityEngine;

[System.Serializable]
public class MonsterData
{
    public SpeciesBase baseData;

    // Runtime stats
    public string nickname;
    public int level;
    [Header("----- Battle Stats -----")]
    public int currentHP;
    public int maxHP;
    public int attack;
    public int defense;
    public int speed;
    [Header("----- Raising Stats -----")]
    public float hunger;
    public float happiness;
    public float discipline;

    public bool isAlive => currentHP > 0;

    public MonsterData(SpeciesBase baseData, int level)
    {
        this.baseData = baseData;
        this.level = level;

        //battle stats
        maxHP = baseData.baseHP + level;
        attack = baseData.baseAttack + level;
        defense = baseData.baseDefense + level;
        speed = baseData.baseSpeed + level;

        currentHP = maxHP;

        hunger = 0;
        happiness = 0;
        discipline = 0;
    }

    public static MonsterData Create(SpeciesBase species, int level)
    {
        return new MonsterData(species, level);
    }
}