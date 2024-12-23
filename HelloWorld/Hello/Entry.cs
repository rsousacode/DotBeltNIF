using System.Runtime.InteropServices;

namespace Hello;

public static class Entry
{
    public static IntPtr Hello()
    {
        return Marshal.StringToHGlobalAnsi("World") ;
    }
}