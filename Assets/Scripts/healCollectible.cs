/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;

public class healCollectible : MonoBehaviour
{


    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            Heal(0.25f);
        }
    }
    public void AddHealth()
    {
        PlayerStats.Instance.AddHealth();
    }

    public void Heal(float health)
    {
        PlayerStats.Instance.Heal(health);
    }

    public void Hurt(float dmg)
    {
        PlayerStats.Instance.TakeDamage(dmg);
    }
}
