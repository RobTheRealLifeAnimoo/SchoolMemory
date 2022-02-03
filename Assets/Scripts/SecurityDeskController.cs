using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SecurityDeskController : MonoBehaviour
{
    public TMP_Text text;
    public Canvas UI;
    bool finishAvailable = false;

    void Start()
    {
        UI.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    void Update(){
        if(Input.GetKey(KeyCode.Return) && finishAvailable == true){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Finish");
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            UI.gameObject.SetActive(true);
            QuestTracker qt = GameObject.FindGameObjectWithTag("QuestTracker").GetComponent<QuestTracker>();
            
            foreach(Quest q in qt.quests){
                if(q.completed == false){
                    finishAvailable = false;
                    return;
                }else{
                    finishAvailable = true;
                }
            }

            if(finishAvailable == true){
                text.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            UI.gameObject.SetActive(false);
        }
    }
}
