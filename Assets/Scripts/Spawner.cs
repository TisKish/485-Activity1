using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ICopy aCopy;

    [SerializeField] private Monster monster;
    private Monster _monster;

    public int spawnX;
    public int spawnY;
    public int spawnZ;

    public Monster SpawnMonster(Monster aPrototype)
    {
        aCopy = aPrototype.Copy();
        return (Monster)aCopy;
    }

    private void Update()
    {
        if (_monster == null)
        {
            _monster = SpawnMonster(monster) as Monster;
            _monster.transform.position = new Vector3(spawnX, spawnY, spawnZ);
        }
    }
}
