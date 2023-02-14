using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSubNumber : MonoBehaviour
{
    [SerializeField] private GameObject m_CaseParent = null;
    [SerializeField] private int m_Number = 0;

    #region Properties
    public GameObject CaseParent { get { return m_CaseParent; } set { m_CaseParent = value; } }   
    public int Number { get { return m_Number; } set { m_Number = value; } }
    #endregion
}
