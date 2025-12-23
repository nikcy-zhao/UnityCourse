using UnityEngine;

public class API04ProjectOnPlane : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        // 把当前游戏对象的向前方向投影到目标的平面上
        Vector3 vector = transform.forward;
        // 目标向上的方向为平面的法线
        Vector3 planeNormal = target.up;
        // 投影
        Vector3 projected = Vector3.ProjectOnPlane(vector, planeNormal);

        // 需要投景的向量
        Debug.DrawRay(transform.position, vector * 10, Color.green);

        // 投影轴方向向量
        Debug.DrawRay(target.position, planeNormal * 10, Color.blue);

        // 投影向量
        Debug.DrawRay(transform.position, projected * 10, Color.yellow);
    }
}
