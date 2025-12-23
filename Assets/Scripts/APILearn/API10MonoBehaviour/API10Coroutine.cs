using UnityEngine;
using System.Collections;

public class API10Coroutine : MonoBehaviour
{
  IEnumerator Start()
  {

    Debug.Log("Main Start");
    yield return new WaitForSeconds(2f);
    StartCoroutine(ExampleCoroutine());
    Debug.Log("Main End");
  }

  //协程方法
  IEnumerator ExampleCoroutine()
  {
    Debug.Log("Coroutine Start");
    ////下一帧继续执行
    //yield return null;
    //Debug.Log("Coroutine Continue");
    yield return new WaitForSeconds(2f);
    StartCoroutine(ExampleCoroutine2());
    Debug.Log("Coroutine End");
  }

  IEnumerator ExampleCoroutine2()
  {
    Debug.Log("Coroutine2 Start");
    yield return new WaitForSeconds(1f);
    Debug.Log("Coroutine2 End");
  }
}
