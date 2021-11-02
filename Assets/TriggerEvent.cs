using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private int damage = 30;
    void onCollisionEnter(Collider col)
    {
        Health health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.HitTaken(damage);
        }
        Debug.Log("reached");
        Destroy(gameObject);
    }
}
