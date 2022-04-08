using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DialogueNPCcontrol : MonoBehaviour
{
    public Dialogue_SO dialogue;
    public GameObject InteractiveUI;
    public GameObject DialoguePanel;
    public GameObject AnswerButtonPre;
    public NPCStoreManager store;
    public Text text;

    int index=0;
    bool istalk;
    Animator anim;
    bool cantalk;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("istalk", istalk);
        if (cantalk && Input.GetKeyDown(KeyCode.T))
        {
            OpenDialoguePanel();
            cantalk = false;
            CloseInteractiveUI();
        }
    }
    public void OpenDialoguePanel()
    {
        DialoguePanel.SetActive(true);
        TaskManager.Instance.UpdateCollectTaskProgress();
        UpdateDialogue();
    }
    public void CloseDialoguePanel()
    {
        DialoguePanel.SetActive(false);
    }
    public void UpdateDialogue()
    {
        if (index >= dialogue.talk.Count)
        {
            CloseDialoguePanel();
            return;
        }
        var talkdate = dialogue.talk[index];
        text.text = "";
        text.DOText(talkdate.str,1f);
        //删除之前的回答选项，0是text文本
        for (int i = 1; i < DialoguePanel.transform.childCount; i++)
        {
            Destroy(DialoguePanel.transform.GetChild(i).gameObject);
        }
        //根据当前对话生成回答按钮
        for (int i = 0; i < talkdate.answers.Count; i++)
        {
            var button = Instantiate(AnswerButtonPre, DialoguePanel.transform);
            if (talkdate.answers[i].taskreply != null)
            {
                if (!TaskManager.Instance.TaskReply(talkdate.answers[i].taskreply))
                {
                    button.GetComponent<DialogueButton>().AnswerRegister(this, talkdate.answers[i].str,true);
                    continue;
                }
            }
            button.GetComponent<DialogueButton>().AnswerRegister(this, talkdate.answers[i].str);
        }
        //若当前对话无回答，则生成NEXT按钮
        if (talkdate.answers.Count < 1)
        {
            var button = Instantiate(AnswerButtonPre, DialoguePanel.transform);
            button.GetComponent<DialogueButton>().AnswerRegister(this, "Next");
        }

    }
    //根据选择的对话确定下一条对话
    public void AnswerClick(int i)
    {
        var talkdate = dialogue.talk[index];
        if (talkdate.answers.Count < 1)
        {
            index++;
            UpdateDialogue();
            return;
        }
        if (talkdate.answers[i].newxtindex != -1)
        {
            
            if (talkdate.answers[i].taskreceive != null)
                TaskManager.Instance.TaskReceive(talkdate.answers[i].taskreceive);
            if (talkdate.answers[i].taskreply != null)
            {
                if (TaskManager.Instance.TaskReply(talkdate.answers[i].taskreply))
                {
                    TaskManager.Instance.FinishReply(talkdate.answers[i].taskreply);
                    index = talkdate.answers[i].newxtindex;
                }
                else
                    return;
            }
            index = talkdate.answers[i].newxtindex;
            if (talkdate.answers[i].closeDialogue)
                CloseDialoguePanel();
            else if (talkdate.answers[i].OpenStore)
            {
                CloseDialoguePanel();
                store.OpenStore();
            }
            else
                UpdateDialogue();

        }
        else
        {
            CloseDialoguePanel();
            OpenInteractiveUI();
            cantalk = true;
        }
    }
    public void OpenInteractiveUI()
    {
        InteractiveUI.SetActive(true);
    }
    public void CloseInteractiveUI()
    {
        InteractiveUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cantalk = true;
            OpenInteractiveUI();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cantalk = false;
            CloseInteractiveUI();
            CloseDialoguePanel();
        }
    }



}
