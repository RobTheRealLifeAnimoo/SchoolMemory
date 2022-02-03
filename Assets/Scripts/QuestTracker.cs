using UnityEngine;
using TMPro;

public class QuestTracker : MonoBehaviour
{
    public Quest[] quests;

    void Start()
    {
        foreach(Quest q in quests){
            q.completed = false;
        }
        RefreshQuestTracker();
    }

    public void RefreshQuestTracker(){
        TMP_Text text = GetComponentInChildren<TMP_Text>();
        text.text = "Úkoly:";
        foreach(Quest q in quests){
            if(q.completed == true){
                text.text += string.Format("\n{0} - Dokončeno", q.description);
            } else {
                text.text += string.Format("\n{0}", q.description);
            }
        }
    }
}
