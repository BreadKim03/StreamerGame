using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    //공격 범위 내 몹 정보를 list로 저장 후 이벤트 처리
    List<GameObject> list = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if (enemy != null && enemy.tag == "Enemy")
        {
            Debug.Log("AddList name" + enemy);
            this.list.Add(enemy);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if (enemy != null && this.list.Contains(enemy) == true)
        {
            Debug.Log("RemoveList name : " + enemy.name);
            this.list.Remove(enemy);
        }
    }

    void AttackEnemy(List<GameObject> enemyList)
    {
        if (transform.GetComponentInParent<PlayerCon>().check == false )
        {
            foreach (GameObject enemy in enemyList)
            {
                Enemy temp = enemy.GetComponent<Enemy>();
                if (!temp.attackCheck)
                {
                    Debug.Log("Attacked name : " + enemy.name);
                    temp.Attack();
                    
                }
            }
            list.Clear();
        }
    }

    public IEnumerator SwingSword()
    {
        if (list != null)
        {
            AttackEnemy(list);
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
        yield return null;
    }
}
