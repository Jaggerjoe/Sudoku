using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubGrid
{
    [SerializeField] private List<CaseNumber> m_CasesNumber  = new List<CaseNumber>();
    
    public SubGrid()
    {
        CreateSubGrid();
    }

    void CreateSubGrid()
    {
        int l_Number = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                //Creation des cases et attribution d'un chiffre
                CaseNumber l_CaseNumber = new CaseNumber(l_Number);
                l_Number++;
                m_CasesNumber.Add(l_CaseNumber);
            }
        }
    }
}
