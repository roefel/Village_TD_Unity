using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Village_TD
{
    class Barrack:Building
    {
        private int swordfighters; //temporary
        public override int maxLevel()
        {
            return 3;
        }

        public int Swordfighters
        {
            get
            {
                return swordfighters;
            }

            set
            {
                swordfighters = value;
            }
        }

        public int createSwordfighter()
        {
            Swordfighters++;    //++ kan eventueel vervangen worden door het ingegeven aantal door de player
            return Swordfighters;
        }
    }
}
