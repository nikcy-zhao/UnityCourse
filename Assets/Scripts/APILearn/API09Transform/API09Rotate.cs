using UnityEngine;

public class API09Rotate : MonoBehaviour
{
    public float angleSpeed = 30f;

    void Start()
    {
        transform.Rotate(new Vector3(45, 45, 45));
    }

    void Update()
    {
        // 以每秒10度的速度旋转物体
        transform.Rotate(Vector3.up, angleSpeed * Time.deltaTime, Space.World);
    }
}
