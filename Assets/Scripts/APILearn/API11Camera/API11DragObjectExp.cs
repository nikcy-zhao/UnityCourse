using UnityEngine;
using UnityEngine.InputSystem;

public class API11DragObjectExp : MonoBehaviour
{
  // 定义新的输入系统
  private PlayerInputs myInput;
  // 使用相机
  public Camera myCamera;
  // 要拖动的物体
  private GameObject myObject;
  // 是否正在拖动
  private bool isDragging = false;
  // 初始颜色
  private Color initialColor;
  // 记录物体的初始位置
  private Vector3 initialPosition;
  // 记录物体被抬起后的高度位置
  private Vector3 liftedPosition;

  void Awake()
  {
    myInput ??= new PlayerInputs();

    if (myCamera == null)
    {
      Debug.LogError("没有指定相机，使用默认主相机");
      myCamera = Camera.main;
    }
  }


  void OnEnable()
  {
    myInput.Enable();
    // 按下鼠标左键
    myInput.Mouse.Click.started += OnClickStarted;
    // 拖动鼠标
    myInput.Mouse.Click.performed += OnClickPerformed;
    // 释放鼠标左键
    myInput.Mouse.Click.canceled += OnClickCanceled;
  }

  void OnDisable()
  {
    myInput.Mouse.Click.started -= OnClickStarted;
    myInput.Mouse.Click.performed -= OnClickPerformed;
    myInput.Mouse.Click.canceled -= OnClickCanceled;
    myInput.Disable();
  }

  private void OnClickStarted(InputAction.CallbackContext context)
  {
    // 通过鼠标位置发射射线
    Ray ray = myCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
    Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 3.0f);

    // 获取射线碰撞信息
    if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, ~LayerMask.GetMask("Ground")))
    {
      if (hitInfo.collider == null) return;
      // 如果碰撞到物体，设置为当前拖动的物体
      myObject = hitInfo.collider.gameObject;
      initialColor = myObject.GetComponent<Renderer>().material.color;
      // 记录物体的初始位置
      initialPosition = myObject.transform.position;
    }
  }

  private void OnClickPerformed(InputAction.CallbackContext context)
  {
    if (myObject == null) return;

    // 让选中的物体变色并且在原位置基础上y轴提升1个单位
    myObject.GetComponent<Renderer>().material.color = Color.green;
    liftedPosition = initialPosition + 0.5f * Vector3.up;
    myObject.transform.position = liftedPosition;

    // 设置为正在拖动
    isDragging = true;
  }

  private void OnClickCanceled(InputAction.CallbackContext context)
  {
    // 释放鼠标左键时，恢复物体颜色和位置
    if (myObject != null)
    {
      isDragging = false;
      myObject.GetComponent<Renderer>().material.color = initialColor;

      // 保持当前位置的 x,z，降低到 initialPosition.y
      Vector3 curr = myObject.transform.position;
      myObject.transform.position = new Vector3(curr.x, initialPosition.y, curr.z);

      // 重置物体
      myObject = null;
    }
  }

  void Update()
  {
    // 如果没有拖动物体，直接返回
    if (!isDragging || myObject == null) return;

    // 获取鼠标在屏幕上的位置
    Vector3 mousePosition = Mouse.current.position.ReadValue();

    // 方法 A：使用 ScreenToWorldPoint（需要深度 z）
    float depth = myCamera.WorldToScreenPoint(myObject.transform.position).z; // 获取物体在屏幕上的深度

    // 通过鼠标位置和深度获取世界坐标
    Vector3 worldA = myCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, depth));

    // 保持物体的抬升高度不变，只改变x和z坐标
    Vector3 newPos = new Vector3(worldA.x, liftedPosition.y, worldA.z);

    // 更新物体位置
    myObject.transform.position = newPos;

    // 方法 B：使用射线检测(推荐使用此方法)
    // Ray ray = myCamera.ScreenPointToRay(mousePosition);     // 通过鼠标位置发射射线到地面来获取世界坐标
    //
    // // 与地面进行射线检测，获取鼠标在地面上的世界坐标
    // if (Physics.Raycast(ray, out RaycastHit hitInfo, LayerMask.GetMask("Ground")))
    // {
    //   // 保持物体的抬升高度不变，只改变x和z坐标
    //   Vector3 newPosition = new Vector3(hitInfo.point.x, liftedPosition.y, hitInfo.point.z);
    //   myObject.transform.position = newPosition;
    // }
  }
}
