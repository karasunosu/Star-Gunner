using UnityEngine;

// Dat trong cac nhan vat co mau (player, enemy)

public class Health : MonoBehaviour
{
    [SerializeField] int hp;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return hp;
    }
}
