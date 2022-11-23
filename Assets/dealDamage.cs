/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;

public class dealDamage : MonoBehaviour
{

    GameObject player;
    public float damage = 0.5f;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (player.transform.position.y < -100) {
            Hurt(1);
            player.transform.position = player.GetComponent<ThirdPersonMovementForces>().checkpoint;
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            Debug.Log("lost a life");
            Hurt(damage);
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
