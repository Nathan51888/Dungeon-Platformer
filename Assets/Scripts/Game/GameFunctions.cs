using UnityEngine;

public static class GameFunctions
{
    public static void Flip (Transform transform)
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public static void Hurt (int currentHealth, int damage)
    {
        currentHealth -= damage;
    }
}