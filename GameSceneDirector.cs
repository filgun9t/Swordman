using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneDirector : MonoBehaviour
{
    void Update()
    {
        //マウスクリックでゲームシーンに遷移する
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");

        }
    }
}