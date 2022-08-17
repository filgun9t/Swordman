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

            //プレイヤーに当たったらHPを減らす
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();

            //連続で当たり判定を出さない
            Invoke("CollisionDelay", 0.5f);

        }
    }
    void CollisionDelay()
    {
        collisionFlag = true;

    }
}
