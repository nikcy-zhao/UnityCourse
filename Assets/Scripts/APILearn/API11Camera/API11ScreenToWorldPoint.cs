using UnityEngine;
using UnityEngine.InputSystem;

public class API11ScreenToWorldPoint : MonoBehaviour
{
  private PlayerInputs myInput;
  public Camera myCamera;
  // 要创建的物体
  public GameObject myObject;

  void Awake()
  {
    myInput ??= new PlayerInputs();
    if (myCamera == null)
      myCamera = Camera.main;
  }

  void OnEnable()
  {
    myInput.Enable();
    myInput.Mouse.Click.performed += OnClickPerformed;
  }

  void OnDisable()
  {
    myInput.Mouse.Click.performed -= OnClickPerformed;
    myInput.Disable();
  }

  void OnClickPerformed(InputAction.CallbackContext context)
  {
    Vector3 mousePosition = Mouse.current.position.ReadValue();
    // 根据鼠标位置和深度计算世界坐标
    Vector3 worldPosition = myCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -10f));
    // 根据获取的世界坐标创建物体
    Instantiate(myObject, worldPosition, Quaternion.identity);
  }
}
