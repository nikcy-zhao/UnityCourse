using UnityEngine;

public class API06Range : MonoBehaviour
{
    void Start()
    {
        Random.InitState(1);
        for (int i = 0; i < 10; i++)
        {
            int randomIntA = Random.Range(1, 10);
            Debug.Log("随机整数A：" + randomIntA);
        }

    }
}
