using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class AttackController : MonoBehaviour {

    public GameObject[] projectile_prefabs;
    public GameObject player;
    public int minimum_attackers;
    public int maximum_attackers;
    public float base_interval;

    private System.Random random;
    protected GameObject[] attackers;

    private void Awake() {
        this.random = new System.Random();
        this.attackers = GameObject.FindGameObjectsWithTag("Attacker");
        this.decrease_base_interval();
    }

    private void decrease_base_interval() {
        // decrease base interval based on current stage
        this.base_interval -= PlayerData.secrets.stage / 20f;
        if (this.base_interval < 0) {
            this.base_interval = 0;
        } 
    }

    private void FixedUpdate() {
        // let attackers focus player
        foreach(GameObject attacker in this.attackers) {
            attacker.transform.up = new Vector2(player.transform.position.x - attacker.transform.position.x,
                                                player.transform.position.y - attacker.transform.position.y);
        }
    }

    private int[] get_unique_ints(int amount, int min, int max) {
        // get specific amount of random unique ints,
        // considering the min and max range (exclusive) 
        // used to choose random attackers
        if (amount > (max - min)) {
            return null;
        }
        // fill array with min - 1 so it can still check min 
        int[] int_array = Enumerable.Repeat(min-1, amount).ToArray();
        int counter = 0;
        while (counter < amount) {
            int random_int = random.Next(min, max);
            if (!Array.Exists<int>(int_array, element => element == random_int)) {
                int_array[counter] = random_int;
                counter++;
            }
        }
        return int_array;
    }

    protected int[] select_random_attackers() {
        int amount_attackers = this.random.Next(this.minimum_attackers, this.maximum_attackers);
        return this.get_unique_ints(amount_attackers, 0, this.attackers.Length);
    }

    protected int get_random_attack() {
        return random.Next(0, this.projectile_prefabs.Length);
    }

    protected void shoot_projectile(GameObject projectile_prefab, Transform transform) {
        // create projectile and apply force to the rigidbody to shoot it
        GameObject instantiated_projectile = Instantiate(projectile_prefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = instantiated_projectile.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * projectile_prefab.GetComponent<Basic_Projectile>().speed, ForceMode2D.Impulse);
    }
}