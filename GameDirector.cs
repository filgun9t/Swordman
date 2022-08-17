using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject player;
    GameObject HPGauge;

    void Start()
    {
        HPGauge = GameObject.Find("HPGauge");

    }

    public void DecreaseHP()
    {
        //�Q�[�W��10%���炷
        HPGauge.GetComponent<Image>().fillAmount -= 0.1f;

        //HP��0�ɂȂ�����Q�[���I�[�o�[��ʂɑJ�ڂ���
        if (HPGauge.GetComponent<Image>().fillAmount == 0)
        {
            player = GameObject.FindWithTag("Player");
            player.GetComponent<Swordman>().Die();

            Invoke("OverTransition", 0.5f);

        }
    }

    void OverTransition()
    {
        SceneManager.LoadScene("GameOverScene");

    }
}
