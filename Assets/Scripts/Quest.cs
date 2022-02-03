using UnityEngine;

[CreateAssetMenu(fileName = "new Quest", menuName ="Quest")]
public class Quest : ScriptableObject
{
    public bool completed = false;
    public string description;
}
