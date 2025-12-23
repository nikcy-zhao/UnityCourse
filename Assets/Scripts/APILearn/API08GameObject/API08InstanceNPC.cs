using UnityEngine;

public class API08InstanceNPC : MonoBehaviour
{
    public GameObject npcPrefab;
    public int npcCount = 10;
    public float radius = 10f;

    void Awake()
    {
        if (npcPrefab == null)
        {
            // 动态加载 NPC 预制体
            npcPrefab = Resources.Load<GameObject>("Prefab/MaleCharacterPBR");
        }
    }

    void Start()
    {
        for (int i = 0; i < npcCount; i++)
        {
            // 随机生成一个点
            Vector2 randomPosition = Random.insideUnitCircle * radius;
            // 以当前物体位置为中心，生成目标位置
            Vector3 targetPosition = transform.position + new Vector3(randomPosition.x, 0, randomPosition.y);
            // 随机生成一个旋转角度
            Quaternion randomRotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
            // 实例化对象
            GameObject npc = Instantiate(npcPrefab, targetPosition, randomRotation, transform);
            npc.name = "NPC " + i;
        }
    }
}
