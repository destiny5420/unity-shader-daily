using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string m_name;
    public string itmeName { get { return m_name; } }
}