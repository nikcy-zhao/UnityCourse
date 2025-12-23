using UnityEngine;
using UnityEngine.InputSystem;

public class IPS02InputActionMap : MonoBehaviour
{
    // 定义 InputActionAsset，用于存储输入系统文件
    public InputActionAsset inputActionAsset;

    // 定义 InputActionMap，用于存储动作映射
    public InputActionMap actionMap;

    private Vector2 moveVector;

    void Start()
    {
        // 通过 InputActionAsset 获取映射
        actionMap = inputActionAsset.FindActionMap("Player");
        // 查找名为Move的动作
        InputAction moveAction = actionMap.FindAction("Move");

        // 给这个动作一个回调
        moveAction.performed += OnMove;
    }

    void Update()
    {
        // 每帧移动
        transform.Translate(new Vector3(moveVector.x, 0, moveVector.y) * 3 * Time.deltaTime);
    }

    void OnMove(InputAction.CallbackContext context)
    {
        // 读取动作的值
        moveVector = context.ReadValue<Vector2>();
    }
}
