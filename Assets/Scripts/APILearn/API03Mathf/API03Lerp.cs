using UnityEngine;

public class API03Lerp : MonoBehaviour
{
    public float startNum = 10f;
    public float endNum = 50f;
    public float t = 0f;

    void Update()
    {
        t += 0.1f;
        if ((endNum - startNum) < 0.01f) return;
        float result = Mathf.Lerp(startNum, endNum, t);

        // 让startNum逐渐接近endNum
        startNum = result;
        Debug.Log(result);
    }
}
