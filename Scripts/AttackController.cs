using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AttackController : MonoBehaviour {

    public GameObject projectile_prefab;
    public GameObject player;

    System.Random random;
    GameObject[] attackers;
    public float projectile_force = 10f;
    // Start is called before the first frame update
    void Start() {
        this.random = new System.Random();
        this.attackers = GameObject.FindGameObjectsWithTag("Attacker");
        StartCoroutine(this.initialize_attacks());
    }

    void FixedUpdate() {
        // needs to get fixed
        foreach(GameObject attacker in this.attackers) {
            Rigidbody2D player_rigidbody = this.player.GetComponent<Rigidbody2D>();
            Rigidbody2D attacker_rigidbody = attacker.GetComponent<Rigidbody2D>();
            Vector2 direction = attacker_rigidbody.position - player_rigidbody.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            attacker_rigidbody.rotation = angle;
        }
    }

    int[] random_unique_ints(int amount, int min, int max) {
        if (amount > (max - min)) {
            return null;
        }
        int[] int_array = new int[amount];
        int counter = 0;
        while (counter < amount) {
            int random_int = random.Next(min, max + 1);
            if (!Array.Exists<int>(int_array, element => element == random_int)) {
                int_array[counter] = random_int;
                counter++;
            }
        }
        return int_array;
    }

    IEnumerator initialize_attacks() {
        while (true) {
            yield return new WaitForSeconds(5);
            GameObject[] chosen_attackers = new GameObject[3];
            int[] random_ints = this.random_unique_ints(3, 0, this.attackers.Length - 1);
            foreach (int random_int in random_ints) {
                GameObject chosen_attacker = this.attackers[random_int];
                this.shoot_projectile(chosen_attacker.transform, chosen_attacker.transform.rotation);
            }
        }
    }

    void shoot_projectile(Transform transform, Quaternion rotation) {
        GameObject projectile = Instantiate(projectile_prefab, transform.position, rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * this.projectile_force, ForceMode2D.Impulse);
    }
}
