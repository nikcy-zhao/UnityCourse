using UnityEngine;

public class API08FindWithTag : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Debug.Log("Found GameObject with tag 'Player': " + player.name);
        }
        else
        {
            Debug.Log("No GameObject found with tag 'Player'");
        }
    }
}
