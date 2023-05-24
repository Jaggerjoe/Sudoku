using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridSudoku 
{
    #region References
    //[SerializeField] List<SubGrid> m_SubGrid = new List<SubGrid>();
    private SubGrid[,] m_SubGridArray = new SubGrid[3, 3];
    #endregion

    #region Properties
    //public List<SubGrid> SubGridList { get { return m_SubGrid; } }
    public SubGrid[,] SubGridArray { get { return m_SubGridArray; } }
    #endregion
    public GridSudoku()
    {
        CreateSubGrid();
        AddRefernceGrid();
        //m_SubGrid.Reverse();
    }

    private void CreateSubGrid()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                m_SubGridArray[i, j] = new SubGrid(i,j);
                //m_SubGrid.Add(m_SubGridArray[i, j]);
            }
        }
    }
    void AddRefernceGrid()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                m_SubGridArray[i, j].Grid = this;
            }
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

    #region Debloquage subcaseNumber
    public void SetSubCaseNumberState()
    {
        List<int> l_Number = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                m_SubGridArray[i,j].GetCurrentSubGrid(l_Number);
                m_SubGridArray[i, j].SetSubCaseNumberState(l_Number);
                l_Number.Clear();
            }
        }
    }

    public void GetSubGridRaw()
    {
        int l_Index = 0;
        List<int> l_Number = new List<int>();
        for (int i = 0; i < 3;)
        {
            for (int j = 0; j < 3;j++)
            {
                m_SubGridArray[i, j].GetCurrentSubGridRow(l_Index, l_Number);
            }
            //Debug.Log($"La taille de ma list est de : {l_Number.Count}");
            SetStateOnSubCaseRaw(i,l_Index, l_Number);
            l_Number.Clear();

            l_Index++;
            if (l_Index > 2)
            {
                i++;
                l_Index = 0;
            }
        }
    }

    public void SetStateOnSubCaseRaw(int p_PosX,int p_Index, List<int> p_NumberToDisplay)
    {
        for (int j = 0; j < 3; j++)
        {
            m_SubGridArray[p_PosX, j].SetSubCaseNumberRow(p_Index,p_NumberToDisplay);
        }
    }

    public void GetSubGridCol()
    {
        int l_Index = 0;
        List<int> l_Number = new List<int>();
        for (int i = 0; i < 3;)
        {
            for (int j = 0; j < 3; j++)
            {
                m_SubGridArray[j,i].GetCurrentSubGridCol(l_Index, l_Number);
            }
            Debug.Log($"La taille de ma list est de : {l_Number.Count}");
            SetStateOnSubCaseCol(i, l_Index, l_Number);
            l_Number.Clear();

            l_Index++;
            if (l_Index > 2)
            {
                i++;
                l_Index = 0;
            }
        }
    }

    public void SetStateOnSubCaseCol(int p_PosY, int p_Index, List<int> p_NumberToDisplay)
    {
        for (int j = 0; j < 3; j++)
        {
            m_SubGridArray[j,p_PosY].SetSubCaseNumberCol(p_Index, p_NumberToDisplay);
        }
    }

    #endregion
}
