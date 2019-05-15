using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class InAndOut : MonoBehaviour {
        private Vector3 originalScale;
        private Vector3 originalPosition;
        float x = 0f;
        float y = 0f;

    private void Start(){
        originalScale = transform.localScale;
        originalPosition = transform.position;
    }

    public IEnumerator ZoomInOut(){
        for (int i = 0; i < 2;i++){
            x = transform.localScale.x*0.985f;
            y = transform.localScale.y*0.985f;
            transform.position=new Vector3(transform.position.x, transform.position.y, transform.position.z - 20);
            while (x > originalScale.x*0.7f && y > originalScale.y*0.7f){
                transform.localScale=new Vector3 (x, y, transform.localScale.z); 
                x = transform.localScale.x*0.985f;
                y = transform.localScale.y*0.985f;
                yield return new WaitForSeconds(.005f);        
            }

            x = transform.localScale.x*1.015f;
            y = transform.localScale.y*1.015f;
            transform.position=new Vector3(transform.position.x, transform.position.y, transform.position.z - 20);
            while (x < originalScale.x*1 && y < originalScale.y*1){
                transform.localScale=new Vector3 (x, y, transform.localScale.z); 
                x = transform.localScale.x*1.015f;
                y = transform.localScale.y*1.015f;
                yield return new WaitForSeconds(.005f);        
            }
            x = originalScale.x*1;
            y = originalScale.y*1;
        }
    }
}