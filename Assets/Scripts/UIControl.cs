using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIControl : UIBehaviour
{
    static Text m_message;

    [SerializeField] Button m_btnNext;
    public static event Action OnNextHandler;

    [SerializeField] Button m_btnPre;
    public static event Action OnPreviousHandler;

    [SerializeField] Button m_btnRotate;
    public static event Action OnRotateHandler;

    protected override void Awake()
    {
        m_message = transform.Find("Control/txtMessage").GetComponent<Text>();
        m_btnNext.onClick.AddListener(()=>{ OnNextHandler.Invoke(); });
        m_btnPre.onClick.AddListener(()=>{ OnPreviousHandler.Invoke(); });
        m_btnRotate.onClick.AddListener(()=>{ OnRotateHandler.Invoke(); });
    }

    public static void SetMessage(string v_msg)
    {
        m_message.text = v_msg;
    }
}
