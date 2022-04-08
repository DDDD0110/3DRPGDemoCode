using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Task", menuName = "SO/Task")]
public class Task_SO : ScriptableObject
{
    public string TaskName;
    public TaskType tasktype;
    [TextArea]
    public string TaskDes;
    public string targetname;
    public int targetnum;
    public int currentnum;
    public bool IsFinish;
    public Item_SO TaskReward;
}
public enum TaskType { CollectItem,KillEnemy};
