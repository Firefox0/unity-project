
using UnityEngine;

public class Stone_Projectile : Basic_Projectile {

    private Rigidbody2D rigidbody_;
    private float deviationValue;

    // Start is called before the first frame update
    void Start() {
        //this.rigidbody_ = this.gameObject.GetComponent<Rigidbody2D>();
        //this.deviationValue = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update() {
        spin();
    }

    void spin() {
        this.transform.Rotate(0, 0, 1);
    }

    void deviation()
    {
        //this.rigidbody_.angularVelocity = deviationValue * this.rotation_speed;
        //this.rigidbody_.velocity = this.transform.up * deviationValue;
    }
}
