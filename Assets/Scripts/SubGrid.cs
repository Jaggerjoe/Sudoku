using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SubGrid
{
    #region References
    private GridSudoku m_Grid = null;
    private CaseNumber[,] m_CaseNum = new CaseNumber[3, 3];
    private GameObject m_SubGridObject = null;
    private int m_PositionSubGridX = 0;
    private int m_PositionSubGridY = 0;
    #endregion

    #region Properties
    public CaseNumber[,] CaseNumber { get { return m_CaseNum; } set { m_CaseNum = value; } }
    public GameObject SubGridObject { get { return m_SubGridObject; } set { m_SubGridObject = value; } }
    public GridSudoku Grid { get { return m_Grid; } set { m_Grid = value; } }

    public int PositionSubgridX { get { return m_PositionSubGridX; } }
    public int PositionSubgridY { get { return m_PositionSubGridY; } }
    #endregion

    public SubGrid(int p_PositionX, int p_PostionY)
    {
        m_PositionSubGridX = p_PositionX;
        m_PositionSubGridY = p_PostionY;
        CreateCaseNumber();
    }

    private void CreateCaseNumber()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                m_CaseNum[i, j] = new CaseNumber(this, i, j);
            }
        }
    }
    public bool CheckNumberIsValid(int p_Number)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (p_Number == m_CaseNum[i, j].Number)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void DesactivateSubCaseNumberOwnSubGrid(int p_Number)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                m_CaseNum[i, j].DesactivateSubCseNumber(p_Number);
            }
        }
    }

    public void DesactivateSubgCaseNumberRow(int p_PositionX, int p_Number)
    {
        for (int k = 0; k < 3; k++)
        {
            m_CaseNum[p_PositionX, k].DesactivateSubCseNumber(p_Number);
        }
    }

    public void DesactivateSubgCaseNumberColum(int p_PositionY, int p_Number)
    {
        for (int i = 0; i < 3; i++)
        {
            m_CaseNum[i, p_PositionY].DesactivateSubCseNumber(p_Number);
        }
    }

    public void ActivateSubCaseNumber()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (m_CaseNum[i, j].SetNumber)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        for (int u = 0; u < 3; u++)
                        {
                            if (m_CaseNum[y, u].SetNumber)
                            {
                                m_CaseNum[i, j].ActivateSubCaseNumber(m_CaseNum[y, u].NumberRef);
                            }
                        }
                    }
                }
            }
        }
    }
}
