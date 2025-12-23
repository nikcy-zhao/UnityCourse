using UnityEngine;

public class API03LerpAngle : MonoBehaviour
{
    // 最大旋转速度
    public float maxRotateSpeed = 30f;

    // 从0达到最大速度需要的时间
    public float duration = 5f;

    // 时间因子
    private float time = 0f;


    void Update()
    {
        // 累加时间因子
        time += Time.deltaTime;

        // 当时间因子累加到5秒时，lerp的因子刚好为1
        float t = Mathf.Clamp01(time / duration);

        // 增加的角度
        float angle = Mathf.LerpAngle(0, maxRotateSpeed, t);

        // 旋转游戏对象
        transform.Rotate(0, angle * Time.deltaTime, 0);
    }
}
