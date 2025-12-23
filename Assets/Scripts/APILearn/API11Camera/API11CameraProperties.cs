using UnityEngine;

public class API11CameraProperties : MonoBehaviour
{
  // 要跟随的相机
  public Camera myCamera;
  // 摄像机相对于角色的位置
  public Vector3 offset = new(0f, 3.5f, -4f);
  // 跟随平滑度
  [Range(0.1f, 10f)]
  public float followSmoothness = 2f;
  // 旋转平滑度
  [Range(0.1f, 10f)]
  public float rotationSmoothness = 2f;
  // 是否启用平滑跟随
  public bool enableSmoothFollow = true;
  // 目标位置和旋转，用于更新相机位置
  private Vector3 targetPosition;
  private Quaternion targetRotation;

  void Start()
  {
    // 确保相机引用存在
    if (myCamera == null)
    {
      //NOTE: 如果没有相机，就绑定第一个启用的相机
      myCamera = Camera.main;
      if (myCamera == null)
      {
        Debug.LogError("未找到相机！请在Inspector中指定相机或确保场景中有MainCamera标签的相机。");
        return;
      }
    }

    // 初始化相机位置和旋转
    UpdateCameraTransform();
  }

  void LateUpdate()
  {
    // 在LateUpdate中更新相机，确保在角色移动后执行
    UpdateCameraTransform();
  }

  private void UpdateCameraTransform()
  {
    if (myCamera == null) return;

    //NOTE: 摄像机跟随角色进行旋转
    Vector3 rotatedOffset = transform.rotation * offset;

    //NOTE: 更新相机位置
    targetPosition = transform.position + rotatedOffset;

    // 计算目标旋转：让相机看向角色，但保持与角色相同的Y轴旋转
    Vector3 directionToTarget = transform.position - targetPosition;
    if (directionToTarget != Vector3.zero)
    {
      targetRotation = Quaternion.LookRotation(directionToTarget);
    }

    // 应用位置和旋转
    if (enableSmoothFollow)
    {
      // 平滑跟随
      Vector3 smoothPosition = Vector3.Lerp(myCamera.transform.position, targetPosition, followSmoothness * Time.deltaTime);
      Quaternion smoothRotation = Quaternion.Slerp(myCamera.transform.rotation, targetRotation, rotationSmoothness * Time.deltaTime);
      myCamera.transform.SetPositionAndRotation(smoothPosition, smoothRotation);
    }
    else
    {
      // 直接跟随
      myCamera.transform.SetPositionAndRotation(targetPosition, targetRotation);
    }
  }
}
