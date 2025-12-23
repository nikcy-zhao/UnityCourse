using UnityEngine;

public class API07FindFirstObjectByType : MonoBehaviour
{
    void Start()
    {
        API07Instantiate target = FindFirstObjectByType<API07Instantiate>();
        if (target != null)
        {
            Debug.Log("找到目标" + target.name);
        }
        else
        {
            Debug.Log("未找到目标");
        }
    }
}
