using UnityEngine;
using System.Collections.Generic;

public class API04MoveTowards : MonoBehaviour
{
    public List<Transform> targets;
    private List<Vector3> targetPositions;
    public float speed = 3f;
    private int index = 0;

    void Start()
    {
        if (targets.Count == 0)
        {
            Debug.LogError("目标未设置");
        }

        targetPositions = new List<Vector3>();
        foreach (Transform target in targets)
        {
            targetPositions.Add(target.position);
        }
    }

    void Update()
    {
        if (index >= targetPositions.Count) return;

        transform.position = Vector3.MoveTowards(transform.position, targetPositions[index], speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPositions[index]) < 0.01f)
        {
            index++;
        }
    }
}
