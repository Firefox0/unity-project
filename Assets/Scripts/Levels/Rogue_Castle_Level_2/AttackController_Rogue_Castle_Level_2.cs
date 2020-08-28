using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController_Rogue_Castle_Level_2 : AttackController {

    private void Start() {
        StartCoroutine(this.initialize_attacks());
    }

    private IEnumerator initialize_attacks() {
        int attack_type;
        int[] selected_attackers_index;

        while (true) {
            yield return new WaitForSeconds(this.base_interval);
            selected_attackers_index = this.select_random_attackers();
            foreach (int index in selected_attackers_index) {
                attack_type = this.get_random_attack();
                switch (attack_type) {
                    case (0):
                        this.shoot_projectile(this.projectile_prefabs[attack_type], this.attackers[index].transform);
                        break;
                    case (1):
                        for (int i = 0; i < 3; i++) {
                            this.shoot_projectile(this.projectile_prefabs[attack_type], this.attackers[index].transform);
                            // blocks the other attacks, but necessary so all projectiles dont spawn on one point, needs improvement
                            yield return new WaitForSeconds(0.2f);
                        }
                        break;
                    case (2):
                        this.shoot_projectile(this.projectile_prefabs[attack_type], this.attackers[index].transform);
                        break;
                }
            }
        }
    }
}
