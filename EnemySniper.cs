using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper : MonoBehaviour
{
    GameObject player;
    [Header("攻撃オブジェクト")] public GameObject attackObject;

    Vector3 PlayerPosition;
    Vector3 EnemyPosition;

    protected SpriteRenderer m_SpriteRender;
    protected Animator m_Animator;

    bool bulletFlag = true;
    int bulletCount = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        PlayerPosition = player.transform.position;
        EnemyPosition = transform.position;

        m_SpriteRender = GetComponent<SpriteRenderer>();
        m_Animator = GetComponent<Animator>();

    }

    void Update()
    {
        //画面内判定
        if (m_SpriteRender.isVisible)
        {
            PlayerPosition = player.transform.position;
            EnemyPosition = transform.position;

            //プレイヤーと敵のX座標の距離を判定
            if (PlayerPosition.x - EnemyPosition.x >= 7.0 && bulletFlag == true)
            {
                //走る
                m_Animator.Play("Run");

                //右に移動する
                transform.localScale = new Vector3(-1, 1, 1);
                EnemyPosition.x = EnemyPosition.x + 0.007f;

                bulletCount = 0;

                if (PlayerPosition.x - EnemyPosition.x < 7.0)
                {
                    //プレイヤーと敵のY座標の距離を判定
                    if (PlayerPosition.y - EnemyPosition.y >= 1.0 || EnemyPosition.y - PlayerPosition.y >= 1.0)
                    {
                        //待機する
                        m_Animator.Play("Idle");

                    }

                    else if (PlayerPosition.y - EnemyPosition.y < 1.0 || EnemyPosition.y - PlayerPosition.y < 1.0)
                    {
                        bulletFlag = false;

                        //待機する
                        m_Animator.Play("Idle");

                        Invoke("Attack", 1.0f);

                        bulletCount += 1;

                    }
                }
            }

            //プレイヤーと敵のX座標の距離を判定
            else if (EnemyPosition.x - PlayerPosition.x >= 7.0 && bulletFlag == true)
            {
                //走る
                m_Animator.Play("Run");

                //左に移動する
                transform.localScale = new Vector3(1, 1, 1);
                EnemyPosition.x = EnemyPosition.x - 0.01f;

                bulletCount = 0;

                if (EnemyPosition.x - PlayerPosition.x < 7.0)
                {
                    //プレイヤーと敵のY座標の距離を判定
                    if (EnemyPosition.y - PlayerPosition.y >= 1.0 || PlayerPosition.y - EnemyPosition.y >= 1.0)
                    {
                        //待機する
                        m_Animator.Play("Idle");

                    }

                    else if (EnemyPosition.y - PlayerPosition.y < 1.0 || PlayerPosition.y - EnemyPosition.y < 1.0)
                    {
                        bulletFlag = false;

                        //待機する
                        m_Animator.Play("Idle");

                        Invoke("Attack", 1.0f);

                        bulletCount += 1;

                    }
                }
            }

            transform.position = EnemyPosition;

        }
    }

    void Attack()
    {
        //一定間隔で3回攻撃する
        if (bulletCount == 1)
        {
            bulletFlag = true;

            //攻撃する
            m_Animator.Play("Attack_Riple");

            //弾を生成する
            GameObject bulletInstantiate = Instantiate(attackObject);
            bulletInstantiate.transform.SetParent(transform);
            bulletInstantiate.transform.position = attackObject.transform.position;
            bulletInstantiate.transform.rotation = attackObject.transform.rotation;
            bulletInstantiate.SetActive(true);

            bulletCount += 1;

            Invoke("Attack2", 0.9f);

        }
    }

    void Attack2()
    {
        if (bulletCount == 2)
        {
            //攻撃する
            m_Animator.Play("Attack_Riple");

            //弾を生成する
            GameObject bulletInstantiate = Instantiate(attackObject);
            bulletInstantiate.transform.SetParent(transform);
            bulletInstantiate.transform.position = attackObject.transform.position;
            bulletInstantiate.transform.rotation = attackObject.transform.rotation;
            bulletInstantiate.SetActive(true);

            bulletCount += 1;

            Invoke("Attack3", 0.9f);

        }
    }

    void Attack3()
    {
        if (bulletCount == 3)
        {
            //攻撃する
            m_Animator.Play("Attack_Riple");

            //弾を生成する
            GameObject bulletInstantiate = Instantiate(attackObject);
            bulletInstantiate.transform.SetParent(transform);
            bulletInstantiate.transform.position = attackObject.transform.position;
            bulletInstantiate.transform.rotation = attackObject.transform.rotation;
            bulletInstantiate.SetActive(true);

            //待機する
            m_Animator.Play("Idle");

        }
    }
}
