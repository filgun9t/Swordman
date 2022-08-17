using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    GameObject player;
    Vector3 PlayerPosition;
    Vector3 EnemyPosition;

    protected Rigidbody2D m_Rigidbody;
    protected CapsuleCollider2D m_CapsulleCollider;
    protected SpriteRenderer m_SpriteRender;
    protected Animator m_Animator;

    bool dieFlag = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        PlayerPosition = player.transform.position;
        EnemyPosition = transform.position;

        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_CapsulleCollider = GetComponent<CapsuleCollider2D>();
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
            if (PlayerPosition.x - EnemyPosition.x >= 3 && dieFlag == false)
            {
                //����
                m_Animator.Play("Orc_boss_Run");

                //�E�Ɉړ�����
                transform.localScale = new Vector3(-2, 2, 1);
                EnemyPosition.x = EnemyPosition.x + 0.01f;

                if (PlayerPosition.x - EnemyPosition.x < 3)
                {
                    //�U������
                    m_Animator.Play("Orc_boss_Attack");

                }
            }

            //�v���C���[�ƓG��X���W�̋����𔻒�
            else if (EnemyPosition.x - PlayerPosition.x >= 3 && dieFlag == false)
            {
                //����
                m_Animator.Play("Orc_boss_Run");

                //���Ɉړ�����
                transform.localScale = new Vector3(2, 2, 1);
                EnemyPosition.x = EnemyPosition.x - 0.01f;

                if (EnemyPosition.x - PlayerPosition.x < 3)
                {
                    //�U������
                    m_Animator.Play("Orc_boss_Attack");

                }
            }

            transform.position = EnemyPosition;

        }
    }

    public void Die()
    {
        Destroy(m_Rigidbody);
        Destroy(m_CapsulleCollider);

        //�|���
        m_Animator.Play("Orc_boss_Die");

        dieFlag = true;
    }
}
