using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGenerator : MonoBehaviour
{
    #region References 
    [SerializeField] GameManager m_GameManager = null;
    [SerializeField] DataLevel m_DataLevel = null;
    [SerializeField] Grid m_Grid = null;
    #endregion

    #region Properties
    public Grid Grid { get { return m_Grid; } }
    #endregion
    private void OnEnable()
    {
        
    }
    public IEnumerator CreateSUdokuGrid()
    {
        int m_Index = 0;

        while(m_DataLevel.m_GridsLevel.Count != 1)
        {
            m_Grid = new Grid();
            m_GameManager.AddGameObject(m_Grid);
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
                                int l_Rdm = Random.Range(1, 10);
                                if (m_Grid.SubGridArray[i, j].CaseNumber[y, u].CanSetNumber())
                                {
                                    if (m_Grid.SubGridArray[i, j].CheckNumberIsValid(l_Rdm) && m_Grid.CheckSubGridColum(y, i, l_Rdm) && m_Grid.CheckSubGridRow(u, j, l_Rdm))
                                    {
                                        m_Grid.SubGridArray[i, j].CaseNumber[y, u].Number = l_Rdm;
                                        m_Grid.SubGridArray[i, j].CaseNumber[y, u].DisplayNumber(l_Rdm);
                                        u++;
                                        m_Index++;
                                    }
                                }
                                else
                                {
                                    //yield return new WaitForSeconds(1f);
                                    ResetGrid(m_Grid);
                                    i = 0;
                                    j = 0;
                                    y = 0; 
                                    u = 0;
                                }
                                //yield return new WaitForSeconds(.10f);
                                yield return null;
                                
                            }
                        }
                    }
                }
                m_DataLevel.m_GridsLevel.Add(m_Grid);
                Debug.Log($"j'en suis a {m_Index}");
            }
        }
    }

    public void ResetGrid(Grid p_Grid)
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
