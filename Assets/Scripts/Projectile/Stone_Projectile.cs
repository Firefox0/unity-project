
using UnityEditor;
using UnityEngine;

public class Stone_Projectile : Basic_Projectile {

    public float time;
    public GameObject cloud_of_smoke;

    // Start is called before the first frame update
    void Start() {
        time = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update() {
        spin();
        this.time -= Time.deltaTime;
        if (time <= 0) {
            Instantiate(cloud_of_smoke, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void spin() {
        this.transform.Rotate(0, 0, 0.5f);
    }
}
