using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomObject : MonoBehaviour {

	private Color overColor = GameConstants.ConvertColor(0, 255, 255, 255);
    private Color selectColor = GameConstants.ConvertColor(150, 0, 0, 255);
    private Color originalColor;
    private Vector3 originalScale;
    private Vector3 originalPosition;

    public GameController gameController;


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

    private void Update(){
        if (mustZoom){
            mustZoom=false;
            StartCoroutine("ZoomIn");
        }
    }

    private void OnMouseEnter() {
        highlighted = true;
        GetComponent<SpriteRenderer>().color = overColor;

        if (gameController.currentPhase == GameConstants.Phase.Start){
            mustZoom=true;
        }
        transform.position=new Vector3(transform.position.x, transform.position.y, transform.position.z - 20);
        x = transform.localScale.x*1.015f;
        y = transform.localScale.y*1.015f;
    }


    IEnumerator ZoomIn(){
        while (x < originalScale.x*1.3 && y < originalScale.y*1.3){
            transform.localScale=new Vector3 (x, y, transform.localScale.z); 
            x = transform.localScale.x*1.015f;
            y = transform.localScale.y*1.015f;
            yield return new WaitForSeconds(.01f);        
        }
        
    }
    

    private void OnMouseExit() {
        highlighted = false;
        StopCoroutine("ZoomIn");
        if (!selected){
            GetComponent<SpriteRenderer>().color = Color.white;
        } else {
            GetComponent<SpriteRenderer>().color = selectColor;
        }
        SetOriginalTransform();
    }

    private void SetOriginalTransform(){
        transform.localScale=originalScale;
        transform.position=originalPosition;
    }

// Esto no va aquí. Zoom object debe encargarse sólo del zoom
    private void CheckSelectCountry(){ // Esto no va aquí. Zoom object debe encargarse sólo del zoom
        bool rightClick = false;
        bool leftClick = false;
        //bool middleClick = false;
        if(Input.GetMouseButtonDown(0)) leftClick = true;
        if(Input.GetMouseButtonDown(1)) rightClick = true;
        //if(Input.GetMouseButtonDown(2)) middleClick = true;

        if (highlighted){
            if (leftClick && !selected){
                GetComponent<SpriteRenderer>().color = selectColor;
                selected = true;
                SetOriginalTransform();
            } else if (rightClick && selected){
                GetComponent<SpriteRenderer>().color = originalColor;
                selected = false;
                SetOriginalTransform();
            }
        }
    }

}