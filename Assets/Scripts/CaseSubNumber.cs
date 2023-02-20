using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CaseSubNumber
{
    #region References
    [SerializeField] int m_Number = 0;
    [SerializeField] GameObject m_SelfCase;
    private CaseNumber m_CaseParent;
    #endregion

    #region Properties
    public CaseNumber CaseParent { get { return m_CaseParent; } set { m_CaseParent = value; } }   
    public int Number { get { return m_Number; } set { m_Number = value; } }
    #endregion

    public CaseSubNumber(int p_Number, GameObject p_SelfCase, CaseNumber p_CaseParent)
    {
        m_Number = p_Number;
        m_SelfCase = p_SelfCase;
        m_CaseParent = p_CaseParent;
    }

    public void AddListenerToButton()
    {
        m_CaseParent.Number = m_Number;
        m_CaseParent.DisplayNumberChoose();
    }
}
