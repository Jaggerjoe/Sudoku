using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CaseNumber 
{
    [SerializeField] private int m_Number = 0;
    //[SerializeField] private int [] m_Values = new int[9];
    [SerializeField] private GameObject[] m_SubCaseNumber = new GameObject[9];
    private GameObject m_Case = null;

    public GameObject Case { get { return m_Case; } set { m_Case = value; } }
    public GameObject[] SubCaseNumber { get { return m_SubCaseNumber; } set { m_SubCaseNumber = value; } }
    public CaseNumber(GameObject p_Object)
    {
        m_Case = p_Object;
    }


}
