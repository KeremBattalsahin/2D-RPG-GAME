using UnityEngine;

public interface IDamegable 
{
    public bool TakeDamage(float damage,float elementalDamage,ElementType element, Transform famageDealer);
}
