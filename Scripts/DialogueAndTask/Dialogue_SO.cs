using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Dialogue",menuName ="SO/Dialogue")]
public class Dialogue_SO : ScriptableObject
{
    public List<Talk> talk = new List<Talk>();
}

[System.Serializable]
public class Talk
{
    public string str;
    public List<Answer> answers = new List<Answer>();
}
[System.Serializable]
public class Answer
{
    public string str;
    public int newxtindex;
    public Task_SO taskreply;
    public Task_SO taskreceive;
    public bool closeDialogue;
    public bool OpenStore;

}
