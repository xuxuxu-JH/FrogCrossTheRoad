using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public void Jump(InputAction.CallbackContext context)
    {
        //TODO:执行跳跃，跳跃的距离，记录分数，播放跳跃的音效
        if (context.phase == InputActionPhase.Performed)
            Debug.Log("Jump" + context);
    }
}
