using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Swordman : PlayerController
{
    GameObject sword;
    bool guardFlag = false;
    bool dieFlag = false;

    void Start()
    {
        sword = GameObject.Find("Weapon-Sword");

        m_Rigidbody = transform.GetComponent<Rigidbody2D>();
        m_CapsulleCollider = transform.GetComponent<CapsuleCollider2D>();
        m_Animator = transform.Find("model").GetComponent<Animator>();

        transform.localScale = new Vector3(-1, 1, 1);

    }

    void Update()
    {
        if (dieFlag == false)
        {
            Action();

            if (m_Rigidbody.velocity.magnitude > 30)
            {
                m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x - 0.1f, m_Rigidbody.velocity.y - 0.1f);

            }

            //画面外に出た場合はゲームオーバーシーンに遷移する
            if (transform.position.y < -5)
            {
                SceneManager.LoadScene("GameOverScene");

            }
        }
    }

    public void Action()
    {
        m_MoveX = Input.GetAxis("Horizontal");

        //攻撃判定
        if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //攻撃する
                m_Animator.Play("Attack");

                //剣のトリガーをオンにする
                var sword_CapsulleCollider = sword.GetComponent<CapsuleCollider2D>();
                sword_CapsulleCollider.isTrigger = true;

                Invoke("SwordTrigger", 0.5f);

            }

            else if (Input.GetKey(KeyCode.S))
            {
                //ガードする
                m_Animator.Play("Guard");
                tag = "PlayerGuard";
                guardFlag = true;
            }

            else if (Input.GetKeyUp(KeyCode.S))
            {
                m_Animator.Play("Idle");
                tag = "Player";
                guardFlag = false;
            }

            else
            {
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

        if (Input.GetKey(KeyCode.D) && guardFlag == false && dieFlag == false)
        {
            //地面にいるとき
            if (m_Rigidbody.velocity.y == 0)
            {
                //攻撃中は移動しない
                if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;

                //押している間、右に移動する
                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);

            }

            else
            {
                //押している間、右に移動する
                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }

            //キャラの向き判定
            if (!Input.GetKey(KeyCode.A))
                Filp(false);

        }

        else if (Input.GetKey(KeyCode.A) && guardFlag == false  && dieFlag == false)
        {
            //地面にいるとき
            if (m_Rigidbody.velocity.y == 0)
            {
                //攻撃中は移動しない
                if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;

                //押している間、左に移動する
                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);

            }

            else
            {
                //押している間、左に移動する
                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }

            //キャラの向き判定
            if (!Input.GetKey(KeyCode.D))
                Filp(true);

        }

        if (Input.GetKeyDown(KeyCode.Space) && m_Rigidbody.velocity.y == 0 && guardFlag == false && dieFlag == false)
        {
            //攻撃中は移動しない
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            //ジャンプ実行
            PrefromJump();

        }
    }

    protected override void LandingEvent()
    {
        //移動中、攻撃中ではないときに待機する
        if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && guardFlag == false && dieFlag == false)
            m_Animator.Play("Idle");
    }

    void SwordTrigger()
    {
        //剣のトリガーをオフにする
        var sword_CapsulleCollider = sword.GetComponent<CapsuleCollider2D>();
        sword_CapsulleCollider.isTrigger = false;

    }

    public void Die()
    {
        Destroy(m_Rigidbody);
        Destroy(m_CapsulleCollider);

        //倒れる
        m_Animator.Play("Die");

        dieFlag = true;
    }
}
