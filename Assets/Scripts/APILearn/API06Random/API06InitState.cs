using UnityEngine;

public class API06InitState : MonoBehaviour
{
    void Start()
    {
        Random.InitState(1);
        // 生成随机整数
        for (int i = 0; i < 10; i++)
        {
            int randomIntB = Random.Range(1, 10);
            Debug.Log("随机整数B：" + randomIntB);
        }

        // 这里没有使用InitState重置生成器，因此生成的随机数序列将继续上一次的状态(Random.InitState(1) + 10)
        for (int i = 0; i < 10; i++)
        {
            int randomIntC = Random.Range(1, 10);
            Debug.Log("随机整数C：" + randomIntC);
        }
    }

}
