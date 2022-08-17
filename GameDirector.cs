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
        //ゲージを10%減らす
        HPGauge.GetComponent<Image>().fillAmount -= 0.1f;

        //HPが0になったらゲームオーバー画面に遷移する
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
