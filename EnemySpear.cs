using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpear : MonoBehaviour
{
    GameObject player;
    Vector3 PlayerPosition;
    Vector3 EnemyPosition;

    protected SpriteRenderer m_SpriteRender;
    protected Animator m_Animator;

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
            if (PlayerPosition.x - EnemyPosition.x >= 1.9)
            {
                //����
                m_Animator.Play("Run");

                //�E�Ɉړ�����
                transform.localScale = new Vector3(-1, 1, 1);
                EnemyPosition.x = EnemyPosition.x + 0.01f;

                if (PlayerPosition.x - EnemyPosition.x < 1.9)
                {
                    //�U������
                    m_Animator.Play("Attack_Spear");

                }

            }

            //�v���C���[�ƓG��X���W�̋����𔻒�
            else if (EnemyPosition.x - PlayerPosition.x >= 1.9)
            {
                //����
                m_Animator.Play("Run");

                //���Ɉړ�����
                transform.localScale = new Vector3(1, 1, 1);
                EnemyPosition.x = EnemyPosition.x - 0.01f;

                if (EnemyPosition.x - PlayerPosition.x < 1.9)
                {
                    //�U������
                    m_Animator.Play("Attack_Spear");

                }
            }

            transform.position = EnemyPosition;

        }
    }
}
