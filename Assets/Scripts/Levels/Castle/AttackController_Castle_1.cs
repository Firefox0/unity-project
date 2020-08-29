using System.Collections;
using UnityEngine;

public class AttackController_Castle_1 : AttackController {

    private void Start() {
        StartCoroutine(this.initialize_attacks());
    }

    private IEnumerator initialize_attacks() {
        int[] selected_attackers_index;

        while (true) {
            yield return new WaitForSeconds(this.base_interval);
            selected_attackers_index = this.select_random_attackers();
            foreach (int index in selected_attackers_index) {
                int randomArrowCount = Random.Range(1, 4);
                //attack_type = this.get_random_attack();
                switch (randomArrowCount) {
                    case 1:
                        this.shoot_projectile(this.projectile_prefabs[0], this.attackers[index].transform);
                        break;
                    case 2:
                        for (int i = 0; i < 2; i++) {
                            this.shoot_projectile(this.projectile_prefabs[0], this.attackers[index].transform);
                            // blocks the other attacks, but necessary so all projectiles dont spawn on one point, needs improvement
                            yield return new WaitForSeconds(0.3f);
                        }
                        break;
                    case 3:
                        for (int i = 0; i < 3; i++)
                        {
                            this.shoot_projectile(this.projectile_prefabs[0], this.attackers[index].transform);
                            // blocks the other attacks, but necessary so all projectiles dont spawn on one point, needs improvement
                            yield return new WaitForSeconds(0.3f);
                        }
                        break;
                    case 4:
                        for (int i = 0; i < 4; i++)
                        {
                            this.shoot_projectile(this.projectile_prefabs[0], this.attackers[index].transform);
                            // blocks the other attacks, but necessary so all projectiles dont spawn on one point, needs improvement
                            yield return new WaitForSeconds(0.3f);
                        }
                        break;
                }
            }
        }
    }
}
