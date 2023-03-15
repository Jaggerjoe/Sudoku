using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGenerator : MonoBehaviour
{
    #region References 
    [SerializeField] GameManager m_GameManager = null;
    [SerializeField] DataLevel m_DataLevel = null;
    [SerializeField] GridSudoku m_Grid = null;
    #endregion

    #region Properties
    public GridSudoku Grid { get { return m_Grid; } }
    #endregion

    public IEnumerator CreateSudokuGrid()
    {
        int m_Index = 0;

        while (m_DataLevel.m_GridsLevel.Count != 100)
        {
            GridSudoku l_Grid = new GridSudoku();
            m_GameManager.AddGameObject(l_Grid);
            m_Index = 0;

            while (m_Index != 81)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            for (int u = 0; u < 3;)
                            {
                                List<int> l_Numbers = l_Grid.SubGridArray[i, j].CaseNumber[y, u].CanSetNumber();
                                if (l_Numbers.Count > 0)
                                {
                                    int l_Rdm = Random.Range(0, l_Numbers.Count);
                                    //Debug.Log($"mon rdm est {l_Rdm} ma value ets donc {l_Numbers[l_Rdm]} ma longueur de tableau est de {l_Numbers.Count}");
                                     //yield return new WaitForSeconds(5f);

                                    if (l_Grid.SubGridArray[i, j].CheckNumberIsValid(l_Numbers[l_Rdm]) && l_Grid.CheckSubGridColum(y, i, l_Numbers[l_Rdm]) && l_Grid.CheckSubGridRow(u, j, l_Numbers[l_Rdm]))
                                    {
                                        l_Grid.SubGridArray[i, j].CaseNumber[y, u].DisplayNumber(l_Numbers[l_Rdm]);
                                        u++;
                                        m_Index++;
                                    }
                                }
                                else
                                {
                                    //yield return new WaitForSeconds(1f);
                                    ResetGrid(l_Grid);
                                    i = 0;
                                    j = 0;
                                    y = 0;
                                    u = 0;
                                    m_Index = 0;
                                }
                                yield return null;
                            }
                        }
                    }
                }
                RemoveNumber(l_Grid);
                l_Grid.GetSubGridRaw();
                l_Grid.GetSubGridCol();
                Debug.Log($"j'en suis a {m_Index}");
                m_DataLevel.m_GridsLevel.Add(l_Grid);
                yield return new WaitForSeconds(5000f);
                //ResetGrid(l_Grid);
            }
        }
        StopCoroutine(CreateSudokuGrid());
    }

    void RemoveNumber(GridSudoku p_Grid)
    {
        int l_Index = 0;

        while(l_Index < 46)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        for (int u = 0; u < 3; u++)
                        {
                            if (l_Index == 46)
                                break;
                            int l_Rdm = Random.Range(0, 2);
                            if (l_Rdm == 1)
                            {
                                p_Grid.SubGridArray[i, j].CaseNumber[y, u].HideCase();
                                l_Index++;
                            }
                        }
                    }
                }
            }
        }
        //DisplayubCase(p_Grid);
    }

    void DisplayubCase(GridSudoku p_Grid)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                p_Grid.SubGridArray[i, j].ActivateSubCaseNumber();
            }
        }
    }

    public void ResetGrid(GridSudoku p_Grid)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int u = 0; u < 3; u++)
                    {
                        p_Grid.SubGridArray[i, j].CaseNumber[y, u].ResetCase();
                    }
                }
            }
        }
    }
}
