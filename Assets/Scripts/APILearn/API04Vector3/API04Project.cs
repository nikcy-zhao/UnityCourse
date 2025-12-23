using UnityEngine;

public class API04Project : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 vector = target.position - transform.position;
        Vector3 onNormal = transform.forward;
        Vector3 projected = Vector3.Project(vector, onNormal);

        // 目标与当前游戏对象的连线
        Debug.DrawLine(transform.position, target.position, Color.green);

        // 投影轴方向向量
        Debug.DrawRay(transform.position, onNormal * 10, Color.blue);

        // 投影向量
        Debug.DrawRay(transform.position, projected, Color.red);
    }
}
