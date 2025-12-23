using UnityEngine;

public class API08CompareTag : MonoBehaviour
{
    void Start()
    {
        // 设置标签
        gameObject.tag = "Player";

        // 比较标签
        bool isPlayer = gameObject.CompareTag("Player");
        Debug.Log("是否是Player:" + isPlayer);
    }
}
