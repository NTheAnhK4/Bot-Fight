using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCtrl : MonoBehaviour
{
    public BotData botData;
    [SerializeField] private int botId = 0;

    public void SpawnBot()
    {
        Transform prefab = PoolingManager.Spawn(botData.data[botId].botPrefab.gameObject, transform.position, default).transform;
        ActorCtrl actorCtrl = prefab.GetComponent<ActorCtrl>();
        actorCtrl.Init(Vector3.right,botData.data[botId].speed,botData.data[botId].weight,botData.data[botId].damage);
        prefab.tag = "Player";
    }
}
