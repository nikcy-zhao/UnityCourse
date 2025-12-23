using UnityEngine;

public class API08FindGameObjectsWithTag : MonoBehaviour
{
    void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject target in targets)
        {
            Debug.Log("找到目标" + target.name);
        }
    }
}
