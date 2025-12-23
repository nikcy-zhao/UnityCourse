using UnityEngine;

public class API09RoateAround : MonoBehaviour
{
    public Transform point;
    public float angleSpeed = 30f;
    public float radius = 10f;

    void Start()
    {
        if (point == null)
        {
            Debug.LogWarning("目标未指定");
            return;
        }

        // 当前游戏对象与point的距离
        Vector3 direction = transform.position - point.position;

        // 归一化direction,并乘以半径就是当前游戏对象到point的距离
        transform.position = point.position + direction.normalized * radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (point == null)
        {
            Debug.LogWarning("目标未指定");
            return;
        }

        transform.RotateAround(point.position, Vector3.up, angleSpeed * Time.deltaTime);
    }
}
