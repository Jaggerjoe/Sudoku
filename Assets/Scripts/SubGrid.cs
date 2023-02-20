using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubGrid
{ 
    #region References
    CaseNumber[,] m_CaseNum = new CaseNumber[3,3];

    [SerializeField] List<CaseNumber> m_CaseDebug = new List<CaseNumber>();
    #endregion

    #region Properties
    public CaseNumber[,] CaseNumber { get { return m_CaseNum; } set{ m_CaseNum = value; } }

    public List<CaseNumber> CaseDebug { get { return m_CaseDebug; } set { m_CaseDebug = value; } }
    #endregion
}
