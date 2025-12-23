using UnityEngine;

[DefaultExecutionOrder(1)]
public class AddComponentTest : MonoBehaviour
{
    private API01FirstScript firstScript;
    void Start()
    {
        gameObject.AddComponent<API01FirstScript>();
        Debug.Log("添加组件成功");

        firstScript = GetComponent<API01FirstScript>();
        Debug.Log("获取组件成功");
    }
}
