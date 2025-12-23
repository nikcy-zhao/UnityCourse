using UnityEngine;

public class API03Method1 : MonoBehaviour
{
    //血量
    public float health = 100f;

    //是否回血
    private bool isHealing = false;

    //一个循环结束
    private bool isOneLoopEnd = false;

    void Update()
    {
        if (isOneLoopEnd)
        {
            return;
        }

        // 不需要回血
        if (health <= 100f && !isHealing)
        {
            health -= 10f * Time.deltaTime;
            health = Mathf.Clamp(health, 0f, 100f);
            Debug.Log("掉血中当前血量为:" + Mathf.Floor(health));

            // 血为0，需要回血
            if (health == 0f)
            {
                isHealing = true;
            }
        }


        if (health >= 0f && isHealing)
        {
            health += 10f * Time.deltaTime;
            health = Mathf.Clamp(health, 0f, 100f);
            Debug.Log("回血中当前血量为：" + Mathf.Floor(health));
            if (health == 100f)
            {
                isHealing = false;
                isOneLoopEnd = true;
            }
        }

    }
}
