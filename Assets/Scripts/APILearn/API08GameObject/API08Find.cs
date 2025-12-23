using UnityEngine;

public class API08Find : MonoBehaviour
{
    void Start()
    {
        // 通过名称查找对象
        GameObject target = GameObject.Find("MaleCharacterPBR");
        if (target != null)
        {
            target.AddComponent<API08InstanceNPC>();
        }
        else
        {
            Debug.Log("未找到目标");
        }
    }

    void Update()
    {

    }
}
