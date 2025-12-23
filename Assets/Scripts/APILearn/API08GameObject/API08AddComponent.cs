using UnityEngine;

public class API08AddComponent : MonoBehaviour
{
    void Start()
    {
        // 添加组件
        API08InstanceNPC instanceNPC = gameObject.AddComponent<API08InstanceNPC>();

        // 修改组件属性
        instanceNPC.npcCount = 5;
    }
}
