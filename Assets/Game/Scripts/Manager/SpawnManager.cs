using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : Singleton<SpawnManager>
{
    public BotData botData;
    public Transform holder;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float coolDown;

    protected override void OnEnable()
    {
        base.OnEnable();
        if (holder == null)
        {
            holder = GameObject.Find("EnemyHolder")?.transform ? GameObject.Find("EnemyHolder")?.transform : new GameObject("EnemyHolder").transform;
        }

        timeSpawn = 3f;
        coolDown = 0f;
    }

    private Vector3 GetRandPos()
    {
        int row = Random.Range(0, 5);
        Vector3 pos = new Vector3(16, 2.5f * row - 3.5f, 0);
        return pos;
    }
    private void Spawn()
    {
        int index = Random.Range(0, botData.data.Count);
        Transform prefab = botData.data[index].botPrefab;
        GameObject enemy = PoolingManager.Spawn(prefab.gameObject, GetRandPos(),default,holder);
        MoveHandler enemyMove = enemy.GetComponent<MoveHandler>();
        enemyMove.Init(Vector3.left,botData.data[index].speed,botData.data[index].weight);
    }

    private void Update()
    {
        coolDown += Time.deltaTime;
        if(coolDown < timeSpawn) return;
        Spawn();
        coolDown = 0;
    }
}
