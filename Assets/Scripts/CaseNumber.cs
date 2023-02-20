using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CaseNumber 
{
    #region References
    [SerializeField] private int m_Number = 0;
    private CaseSubNumber[,] m_SubCaseNumber = new CaseSubNumber[3,3];
    private GameObject m_Case = null;
    private GameObject m_GridSubCase = null;
    private Text m_Text = null;

    [SerializeField] List<CaseSubNumber> m_SubDebug = new List<CaseSubNumber>();
    #endregion

    #region Properties
    public GameObject Case { get { return m_Case; } set { m_Case = value; } }
    public CaseSubNumber[,] SubCaseNumber { get { return m_SubCaseNumber; } set { m_SubCaseNumber = value; } }
    public List<CaseSubNumber> SubDebug { get { return m_SubDebug; } set { m_SubDebug = value; } }
    public int Number { get { return m_Number; }set { m_Number = value; } }
    #endregion

    public CaseNumber(GameObject p_Object, GameObject p_Grid, Text p_Text)
    {
        m_Case = p_Object;
        m_GridSubCase = p_Grid;
        m_Text = p_Text;
    }

    public void DisplayNumberChoose()
    {
        m_GridSubCase.SetActive(false);
        m_Text.text = m_Number.ToString();
        m_Text.fontSize = 54;
        m_Text.enabled = true;
    }
}
