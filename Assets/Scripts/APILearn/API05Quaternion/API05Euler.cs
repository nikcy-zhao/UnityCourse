using UnityEngine;

public class API05Euler : MonoBehaviour
{
    public float angleSpeed = 30f;

    void Update()
    {
        // 以每秒angleSpeed度数的速度旋转物体
        Quaternion rotation = Quaternion.Euler(0, angleSpeed * Time.deltaTime, 0);
        transform.rotation *= rotation;
    }
}
