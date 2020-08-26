using UnityEngine;

public class attacker : MonoBehaviour {

    public GameObject crossbow;
    public GameObject player;
    public GameObject arrowPrefab;

    private float fireRate = 2.0F;
    private float nextArrow = 2.0F;

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
        if (Time.time > nextArrow) {
            nextArrow = Time.time + fireRate;
            GameObject arrow = Instantiate(arrowPrefab, crossbow.transform.position, crossbow.transform.rotation);
            Rigidbody2D rigidbody = arrow.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(transform.up * arrowPrefab.GetComponent<Basic_Projectile>().speed, ForceMode2D.Impulse);
            
        }
    }
}
