using UnityEngine;

public class API02Time : MonoBehaviour
{
    public float timeScale = 1f;
    public float moveSpeed = 3f;

    void Update()
    {
        Time.timeScale = timeScale;

        // 当每帧实际时间过大时，就按照0.016777f来计算
        float clampedDeltaTime = Mathf.Min(Time.unscaledDeltaTime, 0.016777f);
        // 使用新的每帧时间来移动
        transform.Translate(Vector3.forward * moveSpeed * clampedDeltaTime);
    }
}
