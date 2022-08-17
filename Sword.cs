using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sword : MonoBehaviour
{
    GameObject orcBoss;
    float HPCount = 0.0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //�G�ɓ�����������ł�����
            Destroy(collision.gameObject);

        }

        else if(collision.tag == "EnemyBoss")
        {
            //�{�X�ɓ���������HP���J�E���g����
            HPCount++;
            orcBoss = GameObject.FindWithTag("EnemyBoss");

            //�{�X��10�񓖂�������Q�[���N���A��ʂɑJ�ڂ���
            if (HPCount == 10)
            {
                orcBoss.GetComponent<EnemyBoss>().Die();

                Invoke("ClearTransition", 3.0f);
            }
        }
    }

    void ClearTransition()
    {
        SceneManager.LoadScene("GameClearScene");

    }
}
