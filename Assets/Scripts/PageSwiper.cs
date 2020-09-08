using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler {

    private Vector3 panel_location;
    public float percent_threshold = 0.2f;
    public float easing = 0.5f;
    public int total_pages;
    private int current_page = 1;

    void Start() {
        this.panel_location = transform.position;
    }

    public void OnDrag(PointerEventData data) {
        float difference = data.pressPosition.x - data.position.x;
        this.transform.position = this.panel_location - new Vector3(difference, 0, 0);
    }

    public void OnEndDrag(PointerEventData data) {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= this.percent_threshold) {
            Vector3 new_location = this.panel_location;
            if (percentage > 0 && current_page < total_pages) {
                current_page++;
                new_location += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0 && current_page > 1) {
                current_page--;
                new_location += new Vector3(Screen.width, 0, 0);
            }
            StartCoroutine(move_smoothly(transform.position, new_location, this.easing));
            panel_location = new_location;
        }
        else {
            StartCoroutine(move_smoothly(transform.position, panel_location, this.easing));
        }
    }

    IEnumerator move_smoothly(Vector3 start_pos, Vector3 end_pos, float seconds) {
        float t = 0f;
        while (t <= 1.0f) {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(start_pos, end_pos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }

    }
}
