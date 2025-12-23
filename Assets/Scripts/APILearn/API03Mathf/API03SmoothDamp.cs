using UnityEngine;
using System.Collections.Generic;

public class API03SmoothDamp : MonoBehaviour
{
    public float current = 0f;
    public float target = 10f;
    public float velocity = 0f;
    public float smoothTime = 5f;

    [Header("Curve Settings")]
    public AnimationCurve velocityCurve = new AnimationCurve();
    public int maxCurvePoints = 100;

    private List<float> velocityHistory = new List<float>();
    private float timeElapsed = 0f;

    void Update()
    {
        if (current == target) return;

        current = Mathf.SmoothDamp(current, target, ref velocity, smoothTime);

        // 记录velocity值到曲线
        RecordVelocityToCurve();

        Debug.Log("current number: " + current);
        Debug.Log("velocity number:" + velocity);
    }

    void RecordVelocityToCurve()
    {
        timeElapsed += Time.deltaTime;
        velocityHistory.Add(velocity);

        // 限制历史记录数量
        if (velocityHistory.Count > maxCurvePoints)
        {
            velocityHistory.RemoveAt(0);
        }

        // 更新AnimationCurve
        UpdateVelocityCurve();
    }

    void UpdateVelocityCurve()
    {
        velocityCurve.keys = new Keyframe[0]; // 清空现有关键帧

        for (int i = 0; i < velocityHistory.Count; i++)
        {
            float time = (float)i / velocityHistory.Count;
            velocityCurve.AddKey(time, velocityHistory[i]);
        }
    }
}
