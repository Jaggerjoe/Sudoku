using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SubCaseNumber
{
    #region References
    [SerializeField] int m_Number = 0;
    [SerializeField] GameObject m_SelfCase;
    private CaseNumber m_CaseParent;
    private Button m_Button = null;
    private Image m_Image = null;
    #endregion

    #region Porperties
    public int Number { get { return m_Number; } }
    #endregion
    public SubCaseNumber(int p_Number, GameObject p_SelfCase, CaseNumber p_CaseParent)
    {
        m_Number = p_Number;
        m_SelfCase = p_SelfCase;
        m_CaseParent = p_CaseParent;
        m_Button = m_SelfCase.GetComponent<Button>();
        m_Image = m_SelfCase.GetComponent<Image>();
    }

    public void AddListenerToButton()
    {
        m_CaseParent.DisplayNumberChoose(m_Number);
    }

    public void DesactivateCase()
    {
        m_Button.interactable = false;
        ColorBlock l_Cols = m_Button.colors;
        l_Cols.colorMultiplier = 2;
        m_Button.colors = l_Cols;
        m_Image.color = Color.black;
    }
}
