using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CaseNumber 
{
    #region References
    [SerializeField] private int m_Number = 0;
    private int m_PositionX = 0;
    private int m_PositionY = 0;
    private SubCaseNumber[,] m_SubCaseNumber = new SubCaseNumber[3,3];
    private SubGrid m_SubGrid = null;
    private GameObject m_Case = null;
    private GameObject m_GridSubCase = null;
    private Text m_Text = null;

    [SerializeField] List<SubCaseNumber> m_SubDebug = new List<SubCaseNumber>();
    #endregion

    #region Properties
    public GameObject Case { get { return m_Case; } set { m_Case = value; } }
    public SubCaseNumber[,] SubCaseNumber { get { return m_SubCaseNumber; } set { m_SubCaseNumber = value; } }
    public List<SubCaseNumber> SubDebug { get { return m_SubDebug; } set { m_SubDebug = value; } }
    public int Number { get { return m_Number; }set { m_Number = value; } }
    #endregion

    public CaseNumber(GameObject p_Object, GameObject p_Grid, Text p_Text, SubGrid p_SubGrid, int p_PositionX, int p_PositionY)
    {
        m_Case = p_Object;
        m_GridSubCase = p_Grid;
        m_Text = p_Text;
        m_SubGrid = p_SubGrid;
        m_PositionX = p_PositionX;
        m_PositionY = p_PositionY;
    }

    public void DisplayNumberChoose(int p_Number)
    {
        if (m_SubGrid.CheckNumberIsValid(p_Number) && m_SubGrid.Grid.CheckSubGridColum(m_PositionX, m_SubGrid.PositionSubgridX,p_Number) && m_SubGrid.Grid.CheckSubGridRow(m_SubGrid.PositionSubgridY, m_PositionY, p_Number) )
        {
            m_Number = p_Number;
            m_GridSubCase.SetActive(false);
            m_Text.text = m_Number.ToString();
            m_Text.fontSize = 54;
            m_Text.enabled = true;
        }
    }
}
