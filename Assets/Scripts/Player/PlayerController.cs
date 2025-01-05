using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //>Component
    private Rigidbody2D rb;
    private Animator anim;

    //>Variable
    public float jumpDistance;
    private float moveDistance;
    private Vector2 destination;
    private bool buttonHeld;
    //控制移动
    private bool isJump;
    //控制动画
    private bool canJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canJump)
        {
            TriggerJump();
        }
    }

    private void FixedUpdate()
    {
        if (isJump)
            rb.position = Vector2.Lerp(transform.position, destination, 0.134f);
    }

    #region InputCallBackFunction
    public void Jump(InputAction.CallbackContext context)
    {
        //TODO:执行跳跃，跳跃的距离，记录分数，播放跳跃的音效
        //点按一次完成跳跃
        if (context.performed && !isJump)
        {
            moveDistance = jumpDistance;
            destination = new Vector2(transform.position.x, transform.position.y + moveDistance);
            canJump = true;
            Debug.Log("Jump>>>>>>" + moveDistance);
        }
    }

    public void LongJump(InputAction.CallbackContext context)
    {
        //长按
        if (context.performed)
        {
            moveDistance = jumpDistance * 2;
            buttonHeld = true;
        }
        //松开
        if (context.canceled && buttonHeld && !isJump)
        {
            destination = new Vector2(transform.position.x, transform.position.y + moveDistance);
            buttonHeld = false;
            canJump = true;
            Debug.Log("LongJump>>>>>>" + moveDistance);
        }
    }

    public void GetTouchPosition(InputAction.CallbackContext context)
    {

    }
    #endregion


    #region AnimationEvent
    private void TriggerJump()
    {
        //TODO:获得移动方向，播放动画
        canJump = false;
        anim.SetTrigger("Jump");
    }

    public void JumpAnimationEvent()
    {
        isJump = true;
    }

    public void FinishJumpAnimationEvent()
    {
        isJump = false;
    }
    #endregion
}
