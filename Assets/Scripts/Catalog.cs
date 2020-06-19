using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catalog : MonoBehaviour
{
    bool m_bRotating;
    [SerializeField] float m_fRotateSpeed;
    Item[] m_clsItems;
    int m_iCurIndex;
    int m_iItemCnt;

    void Awake()
    {
        m_clsItems = GetComponentsInChildren<Item>(true);
        m_iItemCnt = m_clsItems.Length;

        UIControl.OnNextHandler += OnNextHandler;
        UIControl.OnPreviousHandler += OnPreviousHandler;
        UIControl.OnRotateHandler += OnRotateHandler;
    }

    void Start()
    {
        foreach (var item in m_clsItems)
            item.gameObject.SetActive(false);

        Initialize();
    }

    void Initialize()
    {
        m_iCurIndex = 0;
        OpenItem();
        OnRotateHandler();
    }

    void OnNextHandler()
    {
        m_clsItems[m_iCurIndex].gameObject.SetActive(false);
        m_iCurIndex++;

        if (m_iCurIndex >= m_iItemCnt)
            m_iCurIndex = 0;

        OpenItem();
    }

    void OnPreviousHandler()
    {
        m_clsItems[m_iCurIndex].gameObject.SetActive(false);
        m_iCurIndex--;

        if (m_iCurIndex < 0)
            m_iCurIndex = m_iItemCnt - 1;

        OpenItem();
    }

    void OnRotateHandler()
    {
        m_bRotating = !m_bRotating;
        transform.localEulerAngles = Vector3.zero;
    }

    void OpenItem()
    {
        m_clsItems[m_iCurIndex].gameObject.SetActive(true);
        UIControl.SetMessage(m_clsItems[m_iCurIndex].itmeName);
    }

    void Update()
    {
        if (m_bRotating == true)
        {
            transform.localEulerAngles += new Vector3(0.0f, m_fRotateSpeed * Time.deltaTime, 0.0f);
        }
    }
}
