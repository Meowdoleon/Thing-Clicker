using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    class Game
    {
        static private int thingCounter = 0;

        static public int getThingCounter()
        {
            return thingCounter;
        }

        static public void incrementThingCounter(int i)
        {
            thingCounter += i;
        }

        static public int verifyUnlockableStep()
        {
            if(thingCounter < 5)
            {
                return 0;
            }
            else if (thingCounter < 25)
            {
                return 1;
            }
            else if (thingCounter <300)
            {
                return 2;
            }
            else if (thingCounter < 690)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
    }
}
