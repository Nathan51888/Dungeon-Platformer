using UnityEngine;

public static class CommonFunctions
{
    public static void Flip(Transform transform, bool facingRight, bool canFlip)
    {
        if (!canFlip)
            return;
        
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public static void Hurt(int currentHealth, int damage)
    {
        currentHealth -= damage;
    }
}