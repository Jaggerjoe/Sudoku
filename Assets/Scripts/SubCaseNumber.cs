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
    [SerializeField] bool m_CanSetNumber = true;
    #endregion

    #region Porperties
    public GameObject SelfSubCaseNumber { set { m_SelfCase = value; } }
    public Button Button { set { m_Button = value; } }
    public Image Image { set { m_Image = value; } }
    public int Number { get { return m_Number; } }
    public bool CanSetNumberBool { get { return m_CanSetNumber; } }
    #endregion
    public SubCaseNumber(int p_Number, CaseNumber p_CaseParent)
    {
        m_Number = p_Number;
        m_CaseParent = p_CaseParent;
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
        m_CanSetNumber = false;
    }

    public void ACtiveSubCaseNumber(int p_Number)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if(m_Number == p_Number)
                {
                    ResetCase();
                }
            }
        }
    }
    public void ResetCase()
    {
        m_Button.interactable = true;
        ColorBlock l_Cols = m_Button.colors;
        l_Cols.colorMultiplier = 1;
        m_Button.colors = l_Cols;
        m_Image.color = Color.white;
        m_CanSetNumber = true;
    }
}
