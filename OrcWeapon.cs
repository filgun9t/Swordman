using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcWeapon : MonoBehaviour
{
    bool collisionFlag = true;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collisionFlag == true)
        {
            collisionFlag = false;

            //�v���C���[�ɓ���������HP�����炷
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();

            //�A���œ����蔻����o���Ȃ�
            Invoke("CollisionDelay", 0.5f);

        }
    }
    void CollisionDelay()
    {
        collisionFlag = true;

    }
}
