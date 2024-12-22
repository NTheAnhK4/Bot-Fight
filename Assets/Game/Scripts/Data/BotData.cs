
using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bot Data",menuName = "Data/Bot Data")]
public class BotData : ScriptableObject
{
    public List<BotParam> data;
}

[Serializable]
public class BotParam
{
    public string botName;
    public float weight;
    public float speed;
    public Transform botPrefab;
}
