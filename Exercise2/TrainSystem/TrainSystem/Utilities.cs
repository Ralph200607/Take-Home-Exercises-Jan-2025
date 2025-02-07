using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Utilities
{
    public static bool IsPositiveNonZero(int value)
    {
        return value > 0;
    }

    public static bool InHundreds(int value)
    {
        return value % 100 == 0;
    }
}
