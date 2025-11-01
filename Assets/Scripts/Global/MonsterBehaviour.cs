using UnityEngine;

public abstract class MonsterBehaviour : MonoBehaviour
{
    public MonsterData Data { get; private set; }

    public virtual void Initialize(MonsterData data)
    {
        Data = data;
    }
}