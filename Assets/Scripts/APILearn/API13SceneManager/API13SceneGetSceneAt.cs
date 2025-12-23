using UnityEngine;
using UnityEngine.SceneManagement;

public class API13SceneGetSceneAt : MonoBehaviour
{
  AsyncOperation asyncScene;

  void Start()
  {
    asyncScene = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    asyncScene.completed += OnSceneLoaded;
  }

  void OnSceneLoaded(AsyncOperation op)
  {
    for (int i = 0; i < SceneManager.sceneCount; i++)
      Debug.Log(SceneManager.GetSceneAt(i).name);
  }

}
