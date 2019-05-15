using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Country : MonoBehaviour
{
    public Country[] limits;
    public GameController gameController;
    public string countryName;
    public Army army;
    public Player owner;
    //public GameController gameController;

    private bool highlighted = false;

    // Start is called before the first frame update
    void Start()
    {
        army.gameObject.SetActive(false);

        // army = Resources.Load<Army>("Prefabs/Army");
        // Destroy(GetComponent<PolygonCollider2D>());
        // gameObject.AddComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update(){
        //CheckDropArmy();
        CheckClick();
    }

    private void CheckClick(){
        if(Input.GetMouseButtonDown(0) && highlighted){ //LEFT BUTTON CLICKED
            gameController.clickOnCountry(this);
        }
        
    }

    private void OnMouseEnter() {
        highlighted = true;
    }

    private void OnMouseExit() {
        highlighted = false;
    }

    // private void CheckDropArmy(){
    //     if (gameController.currentPhase == GameConstants.Phase.Reinforcement || gameController.currentPhase == GameConstants.Phase.Start){
    //         if (highlighted){
    //             bool leftClick = false;
    //             if(Input.GetMouseButtonDown(0)) leftClick = true;
    //             if (leftClick && (gameController.currentPlayer == owner || owner == null)){ // && not Occupied for the startphase

    //                 if (owner == null){
    //                     owner = gameController.currentPlayer;
    //                 }
    //                 DropArmy();
    //             }
    //         }
    //     }
    // }

    // private void DropArmy(){
    //     Vector3 countryPos = transform.position;
    //     Debug.Log("Army.number: "+army.numberOfUnits);
    //     if (army.numberOfUnits == 0){
    //         Debug.Log("Pintar ejercito");
    //         SpriteRenderer armySpriteRenderer = army.GetComponent<SpriteRenderer>();
    //         armySpriteRenderer.sprite = Resources.Load<Sprite>("Pics/soldier");
    //         army.transform.localScale = new Vector3(0.1f, 0.1f, 1);
    //         army.numberOfUnits = army.numberOfUnits + 1;
    //         Instantiate(army);
    //         Debug.Log("army pos: "+army.transform.position);
    //         Debug.Log("country pos: "+countryPos);
    //         army.transform.position = new Vector3(countryPos.x, countryPos.y, countryPos.z -1);
    //         Debug.Log("army pos: "+army.transform.position);
    //         army.belongsToCountry = this;
    //     } else {
    //         army.numberOfUnits = army.numberOfUnits + 1;
    //         GameObject text = army.transform.GetChild(0).gameObject;
    //         Debug.Log("text: "+text);
    //         text.GetComponent<TextMeshPro>().text="x"+army.numberOfUnits;
    //     }

    // }

}
