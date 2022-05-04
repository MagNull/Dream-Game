using System;

public interface IDamageable
{
    public event Action<int> Damaged;
    
    void TakeDamage(int damage);
}
