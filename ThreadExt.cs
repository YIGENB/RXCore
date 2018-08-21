using System;
using System.Collections.Generic;
using System.Threading;

namespace RX
{
  public static class ThreadExt
  {
    public static void Thread(this object parameter, ParameterizedThreadStart start)
    {
      new Thread(start).Start(parameter);
    }

    public static void Thread<T>(this T parameter, ParameterizedThreadStart start)
    {
      new Thread(start).Start((object) parameter);
    }

    public static void Thread(this ThreadStart start)
    {
      new Thread(start).Start();
    }
  }
}
