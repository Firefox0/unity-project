using UnityEngine;

public class Crossbow : MonoBehaviour {

    public GameObject crossbow;
    public GameObject player;
    public GameObject arrowPrefab;

    public float fireRate;
    public float nextArrow;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //aimAtPlayer();
        //shootArrow();
    }

    public void aimAtPlayer() {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;

        this.transform.up = new Vector2(playerX - this.transform.position.x, playerY - this.transform.position.y);
    }

    public void shootArrow() {
        if (Time.time > nextArrow) {
            nextArrow = Time.time + fireRate;
            letArrowFly();
        }
    }

    public void letArrowFly() {
        GameObject arrow = Instantiate(arrowPrefab, crossbow.transform.position, crossbow.transform.rotation);
        Rigidbody2D rigidbody = arrow.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * arrowPrefab.GetComponent<Basic_Projectile>().speed, ForceMode2D.Impulse);
    }
}

