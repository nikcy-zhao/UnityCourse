using UnityEngine;

public class API01EventFunc : MonoBehaviour
{
    public int a;
    void Update()
    {
        if (a >= 10) return;
        a = a + 1;
        Debug.Log(a);
    }
}
