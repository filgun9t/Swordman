using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneDirector : MonoBehaviour
{
    void Update()
    {
        //�}�E�X�N���b�N�ŃQ�[���V�[���ɑJ�ڂ���
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");

        }
    }
}