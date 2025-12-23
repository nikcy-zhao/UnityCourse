using UnityEngine;
using UnityEngine.InputSystem;

public class API11ScreenPointToRay : MonoBehaviour
{
  private PlayerInputs myInput;
  public Camera myCamera;

  void Awake()
  {
    myInput ??= new PlayerInputs();
    if (myCamera == null)
    {
      myCamera = Camera.main;
    }
  }

  void OnEnable()
  {
    myInput.Enable();
    myInput.Mouse.Click.performed += OnClick;
  }

  void OnDisable()
  {
    myInput.Mouse.Click.performed -= OnClick;
    myInput.Disable();
  }

  void OnClick(InputAction.CallbackContext context)
  {
    Vector2 mousePosition = Mouse.current.position.ReadValue();

    // 将屏幕坐标转换为射线
    Ray ray = myCamera.ScreenPointToRay(mousePosition);

    // 是否检测到物体
    if (Physics.Raycast(ray, out RaycastHit hitInfo))
    {
      // 改变被点击物体的颜色
      hitInfo.transform.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
    else
    {
      Debug.Log("No object hit");
    }

  }

}

