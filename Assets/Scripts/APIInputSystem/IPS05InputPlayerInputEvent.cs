using UnityEngine;
using UnityEngine.InputSystem;

public class IPS05InputPlayerInputEvent : MonoBehaviour
{
    private Vector2 moveVector;

    void Update()
    {
        // 每帧移动
        transform.Translate(new Vector3(moveVector.x, 0, moveVector.y) * 3 * Time.deltaTime);
    }

    // 通过 PlayerInput 组件，我们可以在 Inspector 中直接绑定输入事件
    public void OnMove(InputAction.CallbackContext context)
    {
        // 读取动作的值
        moveVector = context.ReadValue<Vector2>();
    }
}
