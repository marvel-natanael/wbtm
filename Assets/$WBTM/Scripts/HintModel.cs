using System.Collections.Generic;
using UnityEngine;
 
public class HintModel  
{
    private List<string> _description = new(); 
    public List<string> Hints { get => _description; set => _description = value; }
}
