using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
	private Color overColor = GameConstants.ConvertColor(0, 255, 255, 255);
    private Color selectColor = GameConstants.ConvertColor(150, 0, 0, 255);
    private Color originalColor;
    private Vector3 originalScale;
    private Vector3 originalPosition;

	private bool mustZoom;
    private bool highlighted = false;
    private bool selected = false;
    float x = 0f;
    float y = 0f;

    private void Start(){
        mustZoom = false;
        originalScale = transform.localScale;
        originalPosition = transform.position;
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnMouseEnter() {
        originalColor = GetComponent<SpriteRenderer>().color;
        highlighted = true;
        GetComponent<SpriteRenderer>().color = overColor;
        mustZoom=true;
        transform.position=new Vector3(transform.position.x, transform.position.y, transform.position.z - 20);
        x = transform.localScale.x*1.015f;
        y = transform.localScale.y*1.015f;
    }

    private void OnMouseExit() {
        highlighted = false;
        if (!selected){
            GetComponent<SpriteRenderer>().color = originalColor;
        } else {
            GetComponent<SpriteRenderer>().color = selectColor;
        }
        SetOriginalTransform();
    }

    private void SetOriginalTransform(){
        transform.localScale=originalScale;
        transform.position=originalPosition;
    }
}
