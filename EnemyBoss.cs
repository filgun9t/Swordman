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
        //âÊñ ì‡îªíË
        if (m_SpriteRender.isVisible)
        {
            PlayerPosition = player.transform.position;
            EnemyPosition = transform.position;

            //ÉvÉåÉCÉÑÅ[Ç∆ìGÇÃXç¿ïWÇÃãóó£ÇîªíË
            if (PlayerPosition.x - EnemyPosition.x >= 3 && dieFlag == false)
            {
                //ëñÇÈ
                m_Animator.Play("Orc_boss_Run");

                //âEÇ…à⁄ìÆÇ∑ÇÈ
                transform.localScale = new Vector3(-2, 2, 1);
                EnemyPosition.x = EnemyPosition.x + 0.01f;

                if (PlayerPosition.x - EnemyPosition.x < 3)
                {
                    //çUåÇÇ∑ÇÈ
                    m_Animator.Play("Orc_boss_Attack");

                }
            }

            //ÉvÉåÉCÉÑÅ[Ç∆ìGÇÃXç¿ïWÇÃãóó£ÇîªíË
            else if (EnemyPosition.x - PlayerPosition.x >= 3 && dieFlag == false)
            {
                //ëñÇÈ
                m_Animator.Play("Orc_boss_Run");

                //ç∂Ç…à⁄ìÆÇ∑ÇÈ
                transform.localScale = new Vector3(2, 2, 1);
                EnemyPosition.x = EnemyPosition.x - 0.01f;

                if (EnemyPosition.x - PlayerPosition.x < 3)
                {
                    //çUåÇÇ∑ÇÈ
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

        //ì|ÇÍÇÈ
        m_Animator.Play("Orc_boss_Die");

        dieFlag = true;
    }
}
