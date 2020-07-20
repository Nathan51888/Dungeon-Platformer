using UnityEngine;

public class PlayerHealth
{
    int currentHealth;

    public void HurtPlayer(int damage)
    {
        currentHealth - damage;
    }
}