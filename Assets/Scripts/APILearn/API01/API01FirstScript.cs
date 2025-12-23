using UnityEngine;

public class API01FirstScript : MonoBehaviour
{
    private string playerName = "猪知遥";
    public float health = 100;

    void Start()
    {
        Debug.Log(playerName + "的血量为：" + health);
    }

}

