using UnityEngine;
using UnityEditor;

public class Cloud_Of_Smoke : MonoBehaviour
{
    public float time;
    void Update() {
        time -= Time.deltaTime;
        if (time <= 0) {
            Destroy(this.gameObject);
        }
    }
}