using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RepairersHolder : MonoBehaviour
{
    private List<Repairer> _repairers = new List<Repairer>();

    private void Awake()
    {
        RepairersAssign();
        GameEvents.OnRepair.AddListener(Repair);
    }

    private void RepairersAssign()
    {
        foreach (Transform child in transform)
        {
            child.TryGetComponent(out Repairer repairer);
            
            if(repairer == null)
                Debug.LogError("repairer is not assigned to child: " + child);
            
            else
                _repairers.Add(repairer);
            
        }
    }

    private void Repair()
    {
        var column = GameEvents.currentColumn;
        var curColor = GameEvents.currentColor;
        
        foreach (var repairer in _repairers)
        {
            if (!repairer.Colors.Any(col => curColor.IsEqualTo(col))) continue;
            
            repairer.Repair(column);
            return;
        }
    }
    
    /*private void RandomRepair()
    {
        var rndRep = Random.Range(0, _repairers.Count);
        _repairers[rndRep].Repair();
    }*/
}
