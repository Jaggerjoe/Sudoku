using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid 
{
    #region References
    [SerializeField] List<SubGrid> m_SubGrid = new List<SubGrid>();
    private SubGrid[,] m_SubGridArray = new SubGrid[3, 3];
    #endregion

    #region Properties
    public List<SubGrid> SubGridList { get { return m_SubGrid; } }
    public SubGrid[,] SubGridArray { get { return m_SubGridArray; } }
    #endregion
    public Grid(List<SubGrid> p_ListSubGrid, SubGrid[,] p_SubGrdArray)
    {
        m_SubGridArray = p_SubGrdArray;
        m_SubGrid = p_ListSubGrid;
        AddRefernceGrid();
    }

    void AddRefernceGrid()
    {
        foreach (var item in m_SubGrid)
        {
            item.Grid = this;
        }
    }

    public bool CheckSubGridColum(int p_PositionX,int p_PositionSubGridX, int p_Number)
    {
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                if (m_SubGridArray[p_PositionSubGridX, j].CaseNumber[p_PositionX,k].Number == p_Number)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool CheckSubGridRow(int p_PositionY, int p_PositionSUbGridY, int p_Number)
    {
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                if (m_SubGridArray[j, p_PositionSUbGridY].CaseNumber[k, p_PositionY].Number == p_Number)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void DesactivateSubCaseNumberRow(int p_PositionX,int p_PositionSUbGridX, int p_Number)
    {
        for (int k = 0; k < 3; k++)
        {
            m_SubGridArray[p_PositionSUbGridX, k].DesactivateSubgCaseNumberRow(p_PositionX, p_Number);
        }
    }

    public void DesactivateSubCaseNumberColum(int p_PositionY, int p_PositionSUbGridY, int p_Number)
    {
        for (int i = 0; i < 3; i++)
        {
            m_SubGridArray[i, p_PositionSUbGridY].DesactivateSubgCaseNumberColum(p_PositionY, p_Number);
        }
    }
}
