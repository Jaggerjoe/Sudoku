using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubGrid
{ 
    #region References
    [SerializeField] List<CaseNumber> m_CaseDebug = new List<CaseNumber>();
    CaseNumber[,] m_CaseNum = new CaseNumber[3,3];
    private GameObject m_SubGridObject = null;
    #endregion

    #region Properties
    public CaseNumber[,] CaseNumber { get { return m_CaseNum; } set{ m_CaseNum = value; } }

    public List<CaseNumber> CaseDebug { get { return m_CaseDebug; } set { m_CaseDebug = value; } }
    public GameObject SubGridObject { get { return m_SubGridObject; } }
    #endregion

    public SubGrid(GameObject p_SubGridObject)
    {
        m_SubGridObject = p_SubGridObject;
    }

    public bool CheckNumberIsValid(int p_Numnber)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(p_Numnber == m_CaseNum[i,j].Number)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
