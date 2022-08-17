using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody;
    protected CapsuleCollider2D m_CapsulleCollider;
    protected Animator m_Animator;

    protected float m_MoveX;
    public float MoveSpeed = 6;
    public float jumpForce = 15f;

    protected void AnimatorUpdate()
    {
        //攻撃判定
        if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            //攻撃する
            if (Input.GetKey(KeyCode.Mouse0))
            {
                m_Animator.Play("Attack");

            }

            else
            {
                //移動判定
                if (m_MoveX == 0)
                {
                    //待機する
                    m_Animator.Play("Idle");

                }

                else
                {
                    //走る
                    m_Animator.Play("Run");

                }
            }
        }
    }

    protected void Filp(bool bLeft)
    {
        //キャラの向きを変える
        transform.localScale = new Vector3(bLeft ? 1 : -1, 1, 1);

    }

    protected void PrefromJump()
    {
        //ジャンプ処理
        m_Rigidbody.velocity = new Vector2(0, 0);
        m_Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    }

    protected abstract void LandingEvent();

}
