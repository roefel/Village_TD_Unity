using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Village_TD
{
    class DefenseBuilding:Building
    {
        int defenseFactor;

        public int DefenseFactor
        {
            get{return defenseFactor;}
            set{defenseFactor = value;}
        }
    }
}
