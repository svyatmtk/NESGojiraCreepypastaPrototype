using UnityEngine;

public class Entity : MonoBehaviour
{
    public virtual void GetDamage()
    {
    }

    public virtual void GetDamage(float damage)
    {
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
