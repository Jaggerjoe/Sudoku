using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubCaseNumber
{
    #region References
    [SerializeField] int m_Number = 0;
    [SerializeField] GameObject m_SelfCase;
    private CaseNumber m_CaseParent;
    #endregion

    public SubCaseNumber(int p_Number, GameObject p_SelfCase, CaseNumber p_CaseParent)
    {
        m_Number = p_Number;
        m_SelfCase = p_SelfCase;
        m_CaseParent = p_CaseParent;
    }

    public void AddListenerToButton()
    {
        m_CaseParent.DisplayNumberChoose(m_Number);
    }
}
