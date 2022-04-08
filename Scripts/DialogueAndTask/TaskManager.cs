using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : Singleton<TaskManager>
{
    //[HideInInspector]
    public List<Task_SO> Tasks = new List<Task_SO>();
    public GameObject TaskPanel;
    public Transform TaskListPanel;
    public GameObject TaskButtonPre;
    public Text TaskDes;
    public Text TaskProgress;
    public Image reward;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    public void OpenTaskPanel()
    {
        if (SceneControl.Instance.RetuenSceneName() == "MENU")
            return;
        TaskPanel.SetActive(true);
        UpdateTaskUI();
    }
    public void CloseTaskPanel()
    {
        ShowTaskDes(-1);
        TaskPanel.SetActive(false);
    }
    public void UpdateTaskUI()
    {
        UpdateCollectTaskProgress();
        ClearTaskList();
        for (int i = 0; i < Tasks.Count; i++)
        {
            var tb = Instantiate(TaskButtonPre, TaskListPanel);
            tb.GetComponent<TaskButton>().SetButton(Tasks[i]);
        }
    }
    public void TaskReceive(Task_SO task)
    {
        if (!Tasks.Contains(task))
            Tasks.Add(task);
    }
    public bool TaskReply(Task_SO task)
    {
        int i;
        for (i = 0; i < Tasks.Count; i++)
            if (Tasks[i].TaskName == task.TaskName)
                break;
        if (i>= Tasks.Count)
                return false;
        if (Tasks[i].currentnum >= Tasks[i].targetnum)
        {
            return true;
        }
        return false;
    }
    public void FinishReply(Task_SO task)
    {
        int i;
        for (i = 0; i < Tasks.Count; i++)
            if (Tasks[i].TaskName == task.TaskName)
                break;
        if (i >= Tasks.Count)
            return;
        Tasks[i].IsFinish = true;
        //如果任务类型是收集物品，则在背包中去除响应数量的物品
        if (Tasks[i].tasktype == TaskType.CollectItem)
            InventoryManager.Instance.RemoveItem(Tasks[i].targetname, Tasks[i].targetnum);
        //给PLAYER奖励
        InventoryManager.Instance.TakeItem(Tasks[i].TaskReward);
    }
    public void ShowTaskDes(int i)
    {
        if (i<0)
        {
            TaskDes.text = "";
            TaskProgress.text = "";
            reward.transform.parent.gameObject.SetActive(false);
            return;
        }
        var task = Tasks[i];
        TaskDes.text = task.TaskDes;
        TaskProgress.text = task.currentnum.ToString() + "/" + task.targetnum.ToString();
        if (task.IsFinish)
            TaskProgress.text += "（已完成）";
        reward.transform.parent.gameObject.SetActive(true);
        reward.sprite = task.TaskReward.ItemImage;
    }
    public void ClearTaskList()
    {
        for (int i = 0; i < TaskListPanel.childCount; i++)
        {
            Destroy(TaskListPanel.GetChild(i).gameObject);
        }
    }
    //检查任务目标是否达到
    public void UpdateCollectTaskProgress()
    {
        for (int i = 0; i < Tasks.Count; i++)
        {
            if (Tasks[i].IsFinish)
                continue;
            if (Tasks[i].tasktype == TaskType.CollectItem)
                Tasks[i].currentnum = InventoryManager.Instance.CheckItemNum(Tasks[i].targetname);
            if (Tasks[i].currentnum >= Tasks[i].targetnum)
                Tasks[i].IsFinish = true;
        }
    }
    public void UpdateHuntTaskProgress(string Name)
    {
        for (int i = 0; i < Tasks.Count; i++)
        {
            if (Tasks[i].tasktype == TaskType.KillEnemy)
                if (Tasks[i].targetname == Name)
                    Tasks[i].currentnum++;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            OpenTaskPanel();
    }

}
