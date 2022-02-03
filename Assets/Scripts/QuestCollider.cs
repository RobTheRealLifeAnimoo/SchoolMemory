using UnityEngine;

public class QuestCollider : MonoBehaviour
{
    public Quest quest;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            QuestTracker qt = GameObject.FindGameObjectWithTag("QuestTracker").GetComponent<QuestTracker>();
            foreach(Quest q in qt.quests){
                if(q == quest){
                    q.completed = true;
                    qt.RefreshQuestTracker();
                    Debug.Log("Quest Dokončen!");
                    Destroy(this);
                }
            }
        }
    }
}
