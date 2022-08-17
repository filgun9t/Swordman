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
            //敵に当たったら消滅させる
            Destroy(collision.gameObject);

        }

        else if(collision.tag == "EnemyBoss")
        {
            //ボスに当たったらHPをカウントする
            HPCount++;
            orcBoss = GameObject.FindWithTag("EnemyBoss");

            //ボスに10回当たったらゲームクリア画面に遷移する
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
