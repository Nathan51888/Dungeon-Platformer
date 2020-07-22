using UnityEngine;

public class PlayerHealth
{
    static int currentHealth;
    
    public void SetPlayerMaxHealth()
    {
        currentHealth = PlayerInfo.maxHealth;
    }
}