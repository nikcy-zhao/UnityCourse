using UnityEngine;

[DefaultExecutionOrder(2)]
public class GetComponentTest : MonoBehaviour
{
    private API01FirstScript firstScript;
    private bool isDead = false;
    private float printTime = 0f;

    void Start()
    {
        firstScript = GetComponent<API01FirstScript>();
        Debug.Log("获取组件成功");
    }

    void Update()
    {
        if (isDead) return;

        if (firstScript.health <= 0f)
        {
            Debug.Log("已死亡");
            isDead = true;
            return;
        }

        firstScript.health = firstScript.health - 10f * Time.deltaTime;

        // 每秒打印一次
        printTime += Time.deltaTime;

        if (printTime >= 1f)
        {
            Debug.Log("当前血量为：" + firstScript.health);
            printTime = 0f;
        }
    }
}
