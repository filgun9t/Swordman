using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionController : MonoBehaviour
{
    bool collisionFlag = true;
    [Header("���ӃI�u�W�F�N�g")] public GameObject cautionObject;


    void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[�ɓ��������Ƃ����ӃI�u�W�F�N�g��_�ł�����
        if (collision.tag == "Player" && collisionFlag == true)
        {
            collisionFlag = false;

            cautionObject.SetActive(true);

            Invoke("Caution1", 0.7f);

        }
    }

    void Caution1()
    {
        cautionObject.SetActive(false);

        Invoke("Caution2", 0.7f);

    }

    void Caution2()
    {
        cautionObject.SetActive(true);

        Invoke("Caution3", 0.7f);

    }

    void Caution3()
    {
        cautionObject.SetActive(false);

        Invoke("Caution4", 0.7f);

    }

    void Caution4()
    {
        cautionObject.SetActive(true);

        Invoke("Caution5", 0.7f);

    }

    void Caution5()
    {
        cautionObject.SetActive(false);

    }
}
