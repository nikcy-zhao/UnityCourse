using UnityEngine;

public class API08Active : MonoBehaviour
{
    void Start()
    {
        //激活当前游戏对象
        gameObject.SetActive(true);
        Debug.Log("GameObject is active: " + gameObject.activeSelf);

        //禁用当前游戏对象
        gameObject.SetActive(false);
        Debug.Log("GameObject is active: " + gameObject.activeSelf);
    }
}
