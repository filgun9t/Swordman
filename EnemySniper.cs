using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper : MonoBehaviour
{
    GameObject player;
    [Header("�U���I�u�W�F�N�g")] public GameObject attackObject;

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
        //��ʓ�����
        if (m_SpriteRender.isVisible)
        {
            PlayerPosition = player.transform.position;
            EnemyPosition = transform.position;

            //�v���C���[�ƓG��X���W�̋����𔻒�
            if (PlayerPosition.x - EnemyPosition.x >= 7.0 && bulletFlag == true)
            {
                //����
                m_Animator.Play("Run");

                //�E�Ɉړ�����
                transform.localScale = new Vector3(-1, 1, 1);
                EnemyPosition.x = EnemyPosition.x + 0.007f;

                bulletCount = 0;

                if (PlayerPosition.x - EnemyPosition.x < 7.0)
                {
                    //�v���C���[�ƓG��Y���W�̋����𔻒�
                    if (PlayerPosition.y - EnemyPosition.y >= 1.0 || EnemyPosition.y - PlayerPosition.y >= 1.0)
                    {
                        //�ҋ@����
                        m_Animator.Play("Idle");

                    }

                    else if (PlayerPosition.y - EnemyPosition.y < 1.0 || EnemyPosition.y - PlayerPosition.y < 1.0)
                    {
                        bulletFlag = false;

                        //�ҋ@����
                        m_Animator.Play("Idle");

                        Invoke("Attack", 1.0f);

                        bulletCount += 1;

                    }
                }
            }

            //�v���C���[�ƓG��X���W�̋����𔻒�
            else if (EnemyPosition.x - PlayerPosition.x >= 7.0 && bulletFlag == true)
            {
                //����
                m_Animator.Play("Run");

                //���Ɉړ�����
                transform.localScale = new Vector3(1, 1, 1);
                EnemyPosition.x = EnemyPosition.x - 0.01f;

                bulletCount = 0;

                if (EnemyPosition.x - PlayerPosition.x < 7.0)
                {
                    //�v���C���[�ƓG��Y���W�̋����𔻒�
                    if (EnemyPosition.y - PlayerPosition.y >= 1.0 || PlayerPosition.y - EnemyPosition.y >= 1.0)
                    {
                        //�ҋ@����
                        m_Animator.Play("Idle");

                    }

                    else if (EnemyPosition.y - PlayerPosition.y < 1.0 || PlayerPosition.y - EnemyPosition.y < 1.0)
                    {
                        bulletFlag = false;

                        //�ҋ@����
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
        //���Ԋu��3��U������
        if (bulletCount == 1)
        {
            bulletFlag = true;

            //�U������
            m_Animator.Play("Attack_Riple");

            //�e�𐶐�����
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
            //�U������
            m_Animator.Play("Attack_Riple");

            //�e�𐶐�����
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
            //�U������
            m_Animator.Play("Attack_Riple");

            //�e�𐶐�����
            GameObject bulletInstantiate = Instantiate(attackObject);
            bulletInstantiate.transform.SetParent(transform);
            bulletInstantiate.transform.position = attackObject.transform.position;
            bulletInstantiate.transform.rotation = attackObject.transform.rotation;
            bulletInstantiate.SetActive(true);

            //�ҋ@����
            m_Animator.Play("Idle");

        }
    }
}
