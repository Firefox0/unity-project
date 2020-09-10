using UnityEngine;

public class Head_Projectile : Basic_Projectile
{

    private float time;
    public GameObject poison_cloud;

    // Start is called before the first frame update
    void Start() {
        time = Random.Range(1.0f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        spin();
        this.time -= Time.deltaTime;
        if (time <= 0) {
            Instantiate(poison_cloud, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void spin()  {
        this.transform.Rotate(0, 0, 0.5f);
    }
}
