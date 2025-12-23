using UnityEngine;

public class API04Angle : MonoBehaviour
{
    // 目标
    public Transform target;
    // 视野
    private float fieldOfView = 60f;

    void Update()
    {
        // 计算目标与当前物体正面的夹角
        float angle = Vector3.Angle(target.position - transform.position, transform.forward);

        if (angle < fieldOfView / 2)
        {
            Debug.Log("目标在视野内");
        }
        else
        {
            Debug.Log("目标在视野外");
        }

        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        Debug.DrawRay(transform.position, target.position - transform.position, Color.green);


    }
}
