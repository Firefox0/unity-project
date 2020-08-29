using UnityEngine;

public class Catapult : MonoBehaviour {

    public GameObject catapult;
    public GameObject player;
    public GameObject stonePrefab;

    private float fireRate = 2.0F;
    private float nextStone = 2.0F;

    // Start is called before the first frame update
    void Start() {
        /*this.crossbow = new GameObject();*/
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

    public void shoot() {
        if (Time.time > nextStone) {
            nextStone = Time.time + fireRate;
            GameObject arrow = Instantiate(stonePrefab, catapult.transform.position, catapult.transform.rotation);
            Rigidbody2D rigidbody = arrow.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(transform.up * stonePrefab.GetComponent<Basic_Projectile>().speed, ForceMode2D.Impulse);
            
        }
    }
}

