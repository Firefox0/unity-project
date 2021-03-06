﻿using System.Collections;
using UnityEngine;

public class AttackController_Castle_2 : AttackController {

    private void Start() {
        StartCoroutine(this.initialize_attacks());
    }

    private IEnumerator initialize_attacks() {
        //int attack_type;
        int[] selected_attackers_index;

        while (true) {
            yield return new WaitForSeconds(this.base_interval);
            selected_attackers_index = this.select_random_attackers();
            foreach (int index in selected_attackers_index) {
                this.shoot_projectile(this.projectile_prefabs[0], this.attackers[index].transform);
                //attack_type = this.get_random_attack();
                /*switch (attack_type) {
                    case 1:
                        this.shoot_projectile(this.projectile_prefabs[0], this.attackers[index].transform);
                        break;
                    case 2:
                        this.shoot_projectile(this.projectile_prefabs[0], this.attackers[index].transform);
                        // blocks the other attacks, but necessary so all projectiles dont spawn on one point, needs improvement
                        //yield return new WaitForSeconds(0.3f);
                        break;
                }*/
            }
        }
    }
}
