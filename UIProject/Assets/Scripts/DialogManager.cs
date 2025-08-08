using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class Dialog
{
    public string character;//ĳ����
    public string content; //��ȭ �ؽ�Ʈ

    //������ ��ư -> ���� �۾� �� �����丵 -> ������� ������ ����
    //Ŭ���� ���� �� ȣ��Ǵ� �޼ҵ�(������)
    public Dialog(string character, string content)
    {
        //this�� Ŭ���� �ڽ��� �ǹ��մϴ�.
        //Ŭ������ ���� ���� �Ű������� �̸��� ���Ƽ� �����ϱ� ���� �뵵
        this.character = character;
        this.content = content;
    }
}

public class DialogManager : MonoBehaviour
{
    #region MonoSingleton
    //1) �ڱ� �ڽſ� ���� �ν��Ͻ��� ������.(����)
    public static DialogManager Instance { get; private set; } //������Ƽ
    //Instance�� ���� ���� �� �ֽ��ϴ�.(���� ����)
    //������ �� �� �����ϴ�.

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this; //�ش� �ν��Ͻ��� �ڱ� �ڽ��Դϴ�.
            DontDestroyOnLoad(gameObject);
            //DDOL�� �ش� ��ġ�� �ִ� ������Ʈ��  ���� �Ѿ�� �ı����� �ʰ�
            //���� �����Ǵ� ���� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion




    #region Field
    public TMP_Text message;
    public TMP_Text character_name;
    public GameObject panel;
    public float typing_speed;

    private Queue<Dialog> queue = new Queue<Dialog>();
    private Coroutine typing;
    private bool isTyping = false;
    private Dialog current; //������ ��ȭ ����
    #endregion

    private void Update()
    {
        //�����̽� Ű�� ���� �Է��� ������ٸ�
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //�̺�Ʈ �ý��ۿ� ���޵� ���� �����ϰ�, �� ���� UI ������ ������ ��Ȳ�̶��?
            if(EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                //�۾� X
                return;
            }

            //�����̽� ������ ���������� �۾� ���� ���(��ȭ �Ŵ��� �ְ�, ��ȭ ���� ���)
            if(isTyping) //Ÿ���� ���̸�
            {
                CompleteLine(); //���� �۾��� ���� ������
            }
            else
            {
                NextLine(); //���� �������� �̵��մϴ�.
            }
        }
    }

/// <summary>
/// List<T>�� Queue<T>ó�� ���� ������ �����͸� �� �Ű������� ���� �� �ֽ��ϴ�.
/// </summary>
/// <param name="lines">��ȭ �����Ϳ� ���� ������ ���� ������</param>
    public void StartLine(IEnumerable<Dialog> lines)
    {
        queue.Clear();

        foreach(var line in lines)
        {
            queue.Enqueue(line);
        }
        panel.SetActive(true);
        NextLine();
    }


    //���� �۾��� ���� �Լ�
    private void NextLine()
    {
        //�۾��� ������ �� �̻� ���ٸ�
        if (queue.Count == 0)
        {
            DialogueExit(); //��ȭ�� ����
            return;
        }
        //ť�� ����� ���� �ϳ� ���ɴϴ�.
        current = queue.Dequeue();
        //���� ��ȭ ���� ĳ���� �̸����� ����
        character_name.text = current.character;

        //�ڷ�ƾ�� �����ִ� ���¶�� �����ݴϴ�.
        if(typing != null)
            StopCoroutine(typing);

        //���� ��ȭ �������� ������(��ȭ ����)�� �������� ��ȭ Ÿ������ �����մϴ�.
        typing = StartCoroutine(TypingDialogue(current.content));
    }

    private IEnumerator TypingDialogue(string line)
    {
        isTyping = true;    //Ÿ���� ���� ������ �˸�
        StringBuilder stringBuilder = new StringBuilder(line.Length);
        message.text = ""; //���� ����

        //string(���ڿ�)�� ����(char)�� �迭
        foreach(char c in line)
        {
            //message.text += c;
            stringBuilder.Append(c);
            message.text = stringBuilder.ToString();
            yield return new WaitForSeconds(typing_speed);
        }
        isTyping = false;
    }

    private void DialogueExit()
    {
        panel.SetActive(false); //�г� ����
    }

    //��� ó��
    private void CompleteLine()
    {
        if(typing != null)
            StopCoroutine(typing);

        message.text = current.content;
        isTyping = false;
    }
}
