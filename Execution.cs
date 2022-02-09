 using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
namespace ProcessInfo
{
    class ExecutionSimpleProcess
    {
        public SimpleProcessInfo SP { get; set; }
        public object[] args { get; set; }

        public ExecutionSimpleProcess(SimpleProcessInfo simpleProcess, object[] argF)
        {
            SP = simpleProcess;
            args = argF;
        }
        public object Execution()
        {
            var u = typeof(SampleProcesses).GetMethod(SP.NameOfSimpleProcess);
            return u.Invoke(null, args);
        }
    }
    class ExecupionComplexProcess
    {
        public List<SimpleProcessInfo> ListSP { get; set; }
        public TypeConstructor Constructor { get; set; }

        public object[] args { get; set; }
        public ExecupionComplexProcess(List<SimpleProcessInfo> s, TypeConstructor constructor, object[] argF)
        {
            ListSP = s;
            args = argF;
            Constructor = constructor;
        }
        public object[] CompositionCheckingTypeForCodeExecution()
        {

            object returnVal = null;
            object[] returN = null;
            List<bool> b = new List<bool>();
            if (Constructor == TypeConstructor.Composition)
            {
                for (int i = 0; i < ListSP.Count - 1; i++)
                {
                    Console.Write("параметры сложного процесса", i);
                    for (int j = 0; j < ListSP.ElementAt(i).Args.Count; j++)
                    {

                        Console.Write(ListSP.ElementAt(i).Args.ElementAt(j).ArgType.Name + " " + ListSP.ElementAt(i).Args.ElementAt(j).Name + ",");

                        b.Add(ListSP.ElementAt(i + 1).Args.ElementAt(j).ArgType == ListSP.ElementAt(i).ResultType);
                    }
                    Console.Write("----");
                }
                if (b.Exists(x => x == false))
                {
                    Console.Write("типы не соответствует!");
                }
                else
                {
                    for (int i = 0; i < ListSP.Count; i++)
                    {
                        var u = typeof(SampleProcesses).GetMethod(ListSP.ElementAt(i).NameOfSimpleProcess);
                        if (i == 0)
                        {

                            returnVal = u.Invoke(null, args);
                            returN = new object[] { returnVal };
                        }
                        else
                        {
                            returnVal = u.Invoke(null, returN);
                            returN = new object[] { returnVal };
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < ListSP.Count - 1; i++)
                {
                    for (int j = 0; j < ListSP.ElementAt(i).Args.Count; j++)
                    {

                        Console.Write(ListSP.ElementAt(i).Args.ElementAt(j).ArgType.Name + " " + ListSP.ElementAt(i).Args.ElementAt(j).Name + ",");

                        b.Add(ListSP.ElementAt(i).Args.ElementAt(j).ArgType == args.ElementAt(j).GetType());
                    }
                    Console.Write("----");
                }
                if (b.Exists(x => x == false))
                {
                    Console.Write("типы не соответствует!");
                }
                else
                {
                    returN = new object[ListSP.Count];
                    for (int i = 0; i < ListSP.Count; i++)
                    {
                        var u = typeof(SampleProcesses).GetMethod(ListSP.ElementAt(i).NameOfSimpleProcess);
                        returN[i] = u.Invoke(null, args);
                    }
                }

            }
            return returN;

        }
    }
}