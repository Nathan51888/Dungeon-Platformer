using UnityEngine;

public class PlayerHealth
{
    static int _currentHealth;
    
    public void SetMaxHealth()
    {
        _currentHealth = PlayerInfo.MaxHealth;
    }
}