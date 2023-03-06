using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CaseNumber
{
    #region References
    [SerializeField] private int m_Number = 0;
    private int m_NumberRef = 0;
    private int[] m_Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private int m_PositionX = 0;
    private int m_PositionY = 0;
    private SubCaseNumber[,] m_SubCaseNumber = new SubCaseNumber[3, 3];
    private SubGrid m_SubGrid = null;
    [SerializeField] private GameObject m_Case = null;
    private GameObject m_GridSubCase = null;
    private Text m_Text = null;
    private bool m_CanSetNumber = true;

    #endregion

    #region Properties
    public GameObject Case { get { return m_Case; } set { m_Case = value; } }
    public GameObject GridSubCaseNumber { set { m_GridSubCase = value; } }
    public Text Text { set { m_Text = value; } }
    public SubCaseNumber[,] SubCaseNumber { get { return m_SubCaseNumber; } set { m_SubCaseNumber = value; } }
    public SubGrid SubGrid { get { return m_SubGrid; } }
    public int Number { get { return m_Number; } set { m_Number = value; } }
    public int NumberRef { get { return m_NumberRef; } set { m_NumberRef = value; } }
    public bool SetNumber { get { return m_CanSetNumber; } }
    #endregion

    public CaseNumber(SubGrid p_SubGrid, int p_PositionX, int p_PositionY)
    {
        m_SubGrid = p_SubGrid;
        m_PositionX = p_PositionX;
        m_PositionY = p_PositionY;
        CreateSubCaseNumber();
    }

    private void CreateSubCaseNumber()
    {
        int l_Number = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                m_SubCaseNumber[i, j] = new SubCaseNumber(l_Number, this);
                l_Number++;
            }
        }
    }

    public void DisplayNumberChoose(int p_Number)
    {
        Debug.Log(p_Number);
        if (m_SubGrid.CheckNumberIsValid(p_Number) && m_SubGrid.Grid.CheckSubGridColum(m_PositionX, m_SubGrid.PositionSubgridX, p_Number) && m_SubGrid.Grid.CheckSubGridRow(m_PositionY, m_SubGrid.PositionSubgridY, p_Number))
        {
            Debug.Log("oui");
            m_CanSetNumber = false;
            m_Number = p_Number;
            m_GridSubCase.SetActive(false);
            m_Text.text = m_Number.ToString();
            m_Text.fontSize = 54;
            m_Text.enabled = true;
            m_SubGrid.DesactivateSubCaseNumberOwnSubGrid(p_Number);
            m_SubGrid.Grid.DesactivateSubCaseNumberRow(m_PositionX, m_SubGrid.PositionSubgridX, p_Number);
            m_SubGrid.Grid.DesactivateSubCaseNumberColum(m_PositionY, m_SubGrid.PositionSubgridY, p_Number);
        }
    }

    public void DisplayNumber(int p_Number)
    {
        m_CanSetNumber = false;
        m_Number = p_Number;
        m_GridSubCase.SetActive(false);
        m_Text.text = m_Number.ToString();
        m_Text.fontSize = 54;
        m_Text.enabled = true;
        m_SubGrid.DesactivateSubCaseNumberOwnSubGrid(p_Number);
        m_SubGrid.Grid.DesactivateSubCaseNumberRow(m_PositionX, m_SubGrid.PositionSubgridX, p_Number);
        m_SubGrid.Grid.DesactivateSubCaseNumberColum(m_PositionY, m_SubGrid.PositionSubgridY, p_Number);
    }

    public void DesactivateSubCseNumber(int p_Number)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (m_SubCaseNumber[i, j].Number == p_Number)
                {
                    m_SubCaseNumber[i, j].DesactivateCase();
                }
            }
        }
    }

    public void ActivateSubCaseNumber(int p_Number)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(m_CanSetNumber)
                {
                    m_SubCaseNumber[i, j].ACtiveSubCaseNumber(p_Number);
                }
            }
        }
    }

    public List<int> CanSetNumber()
    {
        int l_SubCaseCantSetNumber = 0;
        List<int> l_NumberVlid = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (!m_SubCaseNumber[i, j].CanSetNumberBool)
                {
                    l_SubCaseCantSetNumber++;
                }
                else
                {
                    l_NumberVlid.Add(m_SubCaseNumber[i, j].Number);
                }
            }
        }
        return l_NumberVlid;
    }

    public void HideCase()
    {
        m_NumberRef = m_Number;
        m_Number = 0;
        m_GridSubCase.SetActive(true);
        m_Text.enabled = false;
        m_CanSetNumber = true;
    }

    public void ResetCase()
    {
        m_Number = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                m_SubCaseNumber[i, j].ResetCase();
                m_GridSubCase.SetActive(true);
                m_Text.enabled = false;
            }
        }
    }
}
