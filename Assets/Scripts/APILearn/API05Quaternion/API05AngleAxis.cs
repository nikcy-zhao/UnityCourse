using UnityEngine;

public class API05AngleAxis : MonoBehaviour
{
    public float angleSpeed = 30f;

    void Update()
    {
        // 以每秒angleSpeed度数的速度旋转物体
        Quaternion rotation = Quaternion.AngleAxis(angleSpeed * Time.deltaTime, Vector3.up);
        transform.rotation *= rotation;
    }
}
