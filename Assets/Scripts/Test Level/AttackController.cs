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
    private Projectile projectile;
    private Projectile projectile_2;
    private Projectile projectile_3;
    System.Random random;
    // all attackers
    GameObject[] attackers;
    public int minimum_attackers = 3;
    public int maximum_attackers = 6;
    public int amount_attacks = 3;
    public float base_interval = 3f;

    // Start is called before the first frame update
    void Start() {
        this.random = new System.Random();
        this.attackers = GameObject.FindGameObjectsWithTag("Attacker");
        this.projectile = new Projectile(this.projectile_prefab, 5f);
        this.projectile_2 = new Projectile(this.projectile_prefab_2, 2.5f);
        this.projectile_3 = new Projectile(this.projectile_prefab_3, 7.5f);
        // coroutines allow functions to be suspended while getting executed, 
        // otherwise the game would be stuck in the loop
        StartCoroutine(this.initialize_attacks());
    }

    void FixedUpdate() {
        // let attackers focus player
        foreach(GameObject attacker in this.attackers) {
            attacker.transform.up = new Vector2(player.transform.position.x - attacker.transform.position.x,
                                                player.transform.position.y - attacker.transform.position.y);
        }
    }

    int[] random_unique_ints(int amount, int min, int max) {
        // get specific amount of random unique ints,
        // considering the min and max range (inclusive) 
        // used to choose random attackers
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
            yield return new WaitForSeconds(this.base_interval);
            // random amount of attackers
            amount_attackers = random.Next(this.minimum_attackers, this.maximum_attackers);
            // pick random attackers
            int[] random_ints = this.random_unique_ints(amount_attackers, 0, this.attackers.Length - 1);
            foreach (int random_int in random_ints) {
                GameObject chosen_attacker = this.attackers[random_int];
                attack_type = random.Next(0, this.amount_attacks);
                switch (attack_type) {
                    case (0):
                        this.shoot_projectile(this.projectile, chosen_attacker.transform);
                        break;
                    case (1):
                        for (int i = 0; i < 5; i++) {
                            this.shoot_projectile(this.projectile_2, chosen_attacker.transform);
                            // blocks the other attacks, but necessary so all projectiles dont spawn on one point, needs improvement
                            yield return new WaitForSeconds(0.2f);
                        }
                        break;
                    case (2):
                        this.shoot_projectile(this.projectile_3, chosen_attacker.transform);
                        break;
                }
            }
        }
    }

    void shoot_projectile(Projectile projectile, Transform transform) {
        // create projectile and apply force to the rigidbody to shoot it
        GameObject instantiated_projectile = Instantiate(projectile.prefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = instantiated_projectile.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * projectile.speed, ForceMode2D.Impulse);
    }
}