using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<PlayerMaster>().HurtPlayer(damage);
    }
}