using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehavior : MonoBehaviour
{
    [SerializeField] private int baseLife;
    [SerializeField] private string enemyTag;
    [SerializeField] private bool isAllyBase;

    private void Update()
    {
        if (isAllyBase)
        {
            GameManager.Instance.uiManager.UpdateBaseLife(baseLife);
            GameManager.Instance.LoseCheck(baseLife);
        }
        else if (!isAllyBase)
        {
            GameManager.Instance.uiManager.UpdateEnemyBaseLife(baseLife);
            GameManager.Instance.WinCheck(baseLife);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(enemyTag))
        {
            baseLife--;
            Destroy(collision.gameObject);
        }
    }
}
