using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CaseNumber 
{
    [SerializeField] private int m_Number = 0;
    [SerializeField] private int [] m_Values = new int[9];
    private GameObject m_Case = null;

    public GameObject Case { get { return m_Case; } set { m_Case = value; } }
    public CaseNumber(GameObject p_Object)
    {
        Number();
        m_Case = p_Object;
    }

    void Number()
    {
        int l_Number = 1;
        for (int i = 0; i < m_Values.Length; i++)
        {
            m_Values[i] = l_Number;
            l_Number++;
        }
    }
}
