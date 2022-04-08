using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskButton : MonoBehaviour
{
    public Text text;

    Task_SO mytask;

    public void SetButton(Task_SO task)
    {
        mytask = task;
        text.text = mytask.TaskName;
    }

    public void ShowTaskDes()
    {
        TaskManager.Instance.ShowTaskDes(transform.GetSiblingIndex());
    }
}
