using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AttackController : MonoBehaviour {

    public GameObject projectile_prefab;
    public GameObject projectile_prefab_2;
    public GameObject projectile_prefab_3;
    public GameObject player;
    System.Random random;
    GameObject[] attackers;

    // Start is called before the first frame update
    void Start() {
        this.random = new System.Random();
        this.attackers = GameObject.FindGameObjectsWithTag("Attacker");
        StartCoroutine(this.initialize_attacks());
    }

    void FixedUpdate() {
        foreach(GameObject attacker in this.attackers) {
            attacker.transform.up = new Vector2(player.transform.position.x - attacker.transform.position.x,
                                                player.transform.position.y - attacker.transform.position.y);
        }
    }

    int[] random_unique_ints(int amount, int min, int max) {
        // get specific amount of random unique ints,
        // considering the min and max range (inclusive) 
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
        int amount_attackers;
        int attack_type;
        while (true) {
            yield return new WaitForSeconds(3);
            // random amount of attackers
            amount_attackers = random.Next(3, 6);
            // pick random attackers and shoot projectile
            int[] random_ints = this.random_unique_ints(amount_attackers, 0, this.attackers.Length - 1);
            foreach (int random_int in random_ints) {
                GameObject chosen_attacker = this.attackers[random_int];
                attack_type = random.Next(0, 3);
                switch (attack_type) {
                    case (0):
                        this.shoot_projectile(chosen_attacker.transform, this.projectile_prefab, 5f);
                        break;
                    case (1):
                        for (int i = 0; i < 5; i++) {
                            this.shoot_projectile(chosen_attacker.transform, this.projectile_prefab_2, 2.5f);
                            // blocks the other attacks, but necessary so all projectiles dont spawn on one point, needs improvement
                            yield return new WaitForSeconds(0.2f);
                        }
                        break;
                    case (2):
                        this.shoot_projectile(chosen_attacker.transform, this.projectile_prefab_3, 7.5f);
                        break;
                }
            }
        }
    }

    void shoot_projectile(Transform transform, GameObject projectile_prefab, float projectile_force) {
        // create projectile and apply force to the rigidbody to shoot it
        GameObject projectile = Instantiate(projectile_prefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * projectile_force, ForceMode2D.Impulse);
    }
}
