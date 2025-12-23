using UnityEngine;

public class API08GetComponent : MonoBehaviour
{
    void Start()
    {
        // 获取子对象身上的组件
        API02TimeScale timeScale = gameObject.GetComponentInChildren<API02TimeScale>();
        timeScale.moveSpeed = 5f;

        // 获取父对象身上的组件
        API08InstanceNPC instanceNPC = gameObject.GetComponentInParent<API08InstanceNPC>();
        instanceNPC.npcCount = 5;

        // 获取对象组件的索引
        int index = gameObject.GetComponentIndex(GetComponent<Transform>());
        Debug.Log(index);

        // 根据父对象组件的索引获取组件
        Component component = instanceNPC.gameObject.GetComponentAtIndex(1);
        Debug.Log(component);
    }
}
