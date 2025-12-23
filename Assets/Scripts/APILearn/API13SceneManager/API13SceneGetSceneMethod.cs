using UnityEngine;
using UnityEngine.SceneManagement;

public class API13SceneGetSceneMethod : MonoBehaviour
{
  void Start()
  {
    Scene scene = SceneManager.GetSceneByBuildIndex(1);
    Debug.Log(scene.name);

    SceneManager.LoadScene(1, LoadSceneMode.Additive);
    scene = SceneManager.GetSceneByBuildIndex(1);
    Debug.Log(scene.name);
  }
}
