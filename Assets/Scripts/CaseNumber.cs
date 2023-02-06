using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CaseNumber 
{
    [SerializeField] private int m_Number = 0;
    
    public CaseNumber(int p_Number)
    {
        m_Number = p_Number;
    }

    void CreateSubCaseNumber()
    {

    }
}
