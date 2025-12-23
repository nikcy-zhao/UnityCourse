using UnityEngine;

public class API04Dot : MonoBehaviour
{
    public Transform target = null;

    void Start()
    {
        if (target == null)
            Debug.LogError("目标未设置");
        if (target == transform)
            Debug.LogError("目标不能是自己");
    }

    void Update()
    {
        float dot = Vector3.Dot((target.position - transform.position).normalized, transform.forward);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (dot > 0f && dot < 1f)
            Debug.Log("目标在侧前方,角度：" + angle);
        if (dot == 1f)
            Debug.Log("目标在正前方,角度：" + angle);
        if (dot == 0f)
            Debug.Log("目标在侧方,角度：" + angle);
        if (dot < 0f && dot > -1f)
            Debug.Log("目标在侧后方,角度：" + angle);
        if (dot == -1f)
            Debug.Log("目标在正后方,角度：" + angle);
    }
}
