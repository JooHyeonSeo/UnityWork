using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject[] obstacles; // ��ֹ� ������Ʈ��
    public GameObject[] Coin;

    private bool stepped = false; // �÷��̾� ĳ���Ͱ� ��Ҿ��°�

    // ������Ʈ�� Ȱ��ȭ�ɶ� ���� �Ź� ����Ǵ� �޼���
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
