using System.Dynamic;
using UnityEngine;

public class Catapult : MonoBehaviour {

    public GameObject[] projectile_prefabs;
    public GameObject catapult;
    public GameObject player;

    private float fire_rate = 2.0F;
    private float next_projectile = 2.0F;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        aimAtPlayer();
        shoot();
    }

    public void aimAtPlayer() {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;

        this.transform.up = new Vector2(playerX - this.transform.position.x, playerY - this.transform.position.y);
    }

    public int get_random_projectile() {
        return Random.Range(0, this.projectile_prefabs.Length);
    }

    public void shoot() {
        // get random projectile from projectile_prefabs array
        GameObject current_projectile = projectile_prefabs[get_random_projectile()];
        // shoot next projectile
        if (Time.time > next_projectile) {
            next_projectile = Time.time + fire_rate;
            GameObject projectile = Instantiate(current_projectile, catapult.transform.position, catapult.transform.rotation);
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(transform.up * current_projectile.GetComponent<Basic_Projectile>().speed, ForceMode2D.Impulse);
            
        }
    }
}

