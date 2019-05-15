using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    //public CanvasController canvasController;
    public Country[] countries;
    public Player[] players;
    public int playerIndex = 0;
    public int maxCountries = 6;
    public Button nextPlayerButton;
    public Image currentPlayerImage;
    public Text currentPlayerName;
    int unitsDropped = 0;

    public Player currentPlayer = null;
    //public int maxPlayers = 3;

    public GameConstants.Phase currentPhase;
    private bool phaseChange = false;

    // Start is called before the first frame update
    void Start(){
        currentPlayer = players[playerIndex];
        currentPhase = GameConstants.Phase.Start;
        currentPlayer.droppedArmy = false;
        currentPlayerImage.sprite = currentPlayer.meeple;
        currentPlayerName.text = currentPlayer.playerName;
    }

    // Update is called once per frame
    void Update(){ //EN REALIDAD ESTO NO SE TIENE QUE HACER EN CADA PUTO FRAME. UN EVENTO CLICK LO DISPARARÁ.
        // if (phaseChange){
        //     changePhase();
        // }
    }

    // void changePhase(){
    //     switch (currentPhase){
    //         case GameConstants.Phase.Start:
    //             currentPhase = GameConstants.Phase.Reinforcement;
    //             Debug.Log("Cambiamos a fase de refuerzos");
    //             break;
    //         case GameConstants.Phase.Reinforcement:
    //             currentPhase = GameConstants.Phase.Combat;
    //             Debug.Log("Cambiamos a fase de combate");
    //             break;
    //         case GameConstants.Phase.Combat:
    //             currentPhase = GameConstants.Phase.Relocate;
    //             Debug.Log("Cambiamos a fase de reubicación");
    //             break;
    //         case GameConstants.Phase.Relocate:
    //             currentPhase = GameConstants.Phase.Reinforcement;
    //             Debug.Log("Cambiamos a fase de refuerzos y cambiamos de jugador"); //Más adelante comprobar si el jugador tiene cartas para cambiar
    //             break;
    //     }
    // }

    public void clickOnCountry(Country countryClicked){
        switch (currentPhase){
            case GameConstants.Phase.Start:
                Debug.Log("FASE DE INICIO. DROPEAR EJERCITOS POR TODO EL MAPA");
                if (!currentPlayer.droppedArmy){
                    if (maxCountries > unitsDropped){ //Debe quedar algún país vacío
                        if (countryClicked.army.units == 0){ //Si se hace click sobre un país vacío
                            countryClicked.army.units += 1;
                            Debug.Log("countryClicked.army.units: "+countryClicked.army.units);
                            countryClicked.army.gameObject.SetActive(true);
                            countryClicked.army.GetComponent<SpriteRenderer>().sprite = currentPlayer.meeple;
                            countryClicked.owner = currentPlayer;
                            currentPlayer.droppedArmy = true;
                            unitsDropped+=1;
                        }
                    } else {
                        if (countryClicked.owner == currentPlayer && currentPlayer.currentUnits > 0){
                            currentPlayer.currentUnits -=1;
                            countryClicked.army.units += 1;
                            Debug.Log("countryClicked.army.units: "+countryClicked.army.units);
                            countryClicked.army.textUnits.text = "x"+countryClicked.army.units.ToString();
                            unitsDropped+=1;
                            currentPlayer.droppedArmy = true;
                        }
                    }
                } else { //Poner a parpadear el botoncico de next player
                    Debug.Log("//Hay que activar el botón de cambio de turno");
                    StartCoroutine(nextPlayerButton.GetComponent<InAndOut>().ZoomInOut());
                }
                break;
            case GameConstants.Phase.Combat:
                Debug.Log("FASE DE COMBATE. SELECCIONAR ATACANTE");
                break;
            case GameConstants.Phase.Relocate:
                Debug.Log("FASE DE REUBICACIÓN. SELECCIONAR 2 CIUDADES CONECTADAS ENTRE SÍ");
                break;
            case GameConstants.Phase.Reinforcement:
                Debug.Log("FASE DE REFUERZOS.");
                break;
        }
    }

    public void changeTurn(){
        StopAllCoroutines();
        //Debug.Log("last player: "+currentPlayer.name);
        currentPlayer.droppedArmy = false;
        playerIndex += 1;
        if (playerIndex >= players.Length){
            playerIndex = 0;
        }
        currentPlayer = players[playerIndex];
        currentPlayerImage.sprite = currentPlayer.meeple;
        Debug.Log("cpN: "+currentPlayerName.text);
        currentPlayerName.text = currentPlayer.playerName;
        currentPlayerImage.sprite = currentPlayer.meeple;
        Debug.Log("Realizar cambio de turno");
        //canvasController.nextPlayerButton.OnPointerUp.
    }

    public void ActivatePhaseChange(){
        phaseChange = true;
    }

    public void DropArmy(){

    }

}
