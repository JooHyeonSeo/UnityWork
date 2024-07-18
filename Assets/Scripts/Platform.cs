using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject[] obstacles; // 장애물 오브젝트들
    public GameObject[] Coin;

    private bool stepped = false; // 플레이어 캐릭터가 밟았었는가

    // 컴포넌트가 활성화될때 마다 매번 실행되는 메서드
    private void OnEnable()
    {
        stepped = false;
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
        for (int i = 0; i < Coin.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                Coin[i].SetActive(true);
            }
            else
            {
                Coin[i].SetActive(false);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }


}
