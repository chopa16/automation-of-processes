using ConsoleApp2;
using ProcessInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Type t = typeof(SampleProcesses);
            MethodInfo[] MArr = t.GetMethods();


            List<string> NameOfSP = new List<string>();
            NameOfSP.Add("f21");
            NameOfSP.Add("f22");
            NameOfSP.Add("f23");
            TypeConstructor constructor = TypeConstructor.Composition;
            object[] arg = new object[] { 1 };
            object[] intermediateResult;
            if (NameOfSP.Count > 0)
            {
                if (NameOfSP.Count > 1)
                {
                    List<SimpleProcessInfo> listOfSimpleProcesses = new List<SimpleProcessInfo>();
                    List<ArgInfo> argS = null;
                    Type resultType1 = null;
                    for (int i = 0; i < NameOfSP.Count; i++)
                    {

                        List<ArgInfo> arGs = new List<ArgInfo>();

                        var Process1 = t.GetMethod(NameOfSP.ElementAt(i));
                        var mProcessParametres = Process1.GetParameters();
                        for (int j = 0; j < mProcessParametres.Length; j++)
                        {
                            Type vd = mProcessParametres[j].ParameterType;

                            arGs.Add(new ArgInfo(mProcessParametres[j].ParameterType, mProcessParametres[j].Name, j));
                            if (i < 1)
                            {
                                argS = arGs;
                            }
                        }

                        listOfSimpleProcesses.Add(new SimpleProcessInfo(arGs, NameOfSP.ElementAt(i), Process1.ReturnType));
                        if (NameOfSP.Count - 1 == i)
                        {
                            resultType1 = Process1.ReturnType;
                        }
                    }
                    if (NameOfSP.Count > 0)
                    {
                        Console.Write(" --------" + resultType1.Name + "- resultType");
                        for (int i = 0; i < argS.Count; i++)
                        {
                            Console.Write(argS[i].ArgType.Name + " " + argS[i].Name + " " + argS[i].Index);
                        }
                        ComplexProcessInfo ComplexProcessInfoP = new ComplexProcessInfo(argS, resultType1, listOfSimpleProcesses, "", constructor);
                        var v = new ExecupionComplexProcess(listOfSimpleProcesses, constructor, arg);
                        if (constructor == TypeConstructor.Parallel)
                        {
                            intermediateResult = new object[listOfSimpleProcesses.Count];
                        }
                        else
                        {
                            intermediateResult = new object[1];
                        }
                        intermediateResult = v.CompositionCheckingTypeForCodeExecution();
                        var h = intermediateResult[0];//резултат выполнение композиции или паралельного процесса
                        Console.Write(intermediateResult[0]); //вместо нуля можно подставить 1 или 2, для проверки результата

                    }
                }
                else
                {
                    var Process1 = t.GetMethod(NameOfSP.ElementAt(0));
                    var mProcessParametres = Process1.GetParameters();
                    List<ArgInfo> argList = new List<ArgInfo>();
                    for (int j = 0; j < mProcessParametres.Length; j++)
                    {
                        Type vd = mProcessParametres[j].ParameterType;
                        argList.Add(new ArgInfo(mProcessParametres[j].ParameterType, mProcessParametres[j].Name, j));
                    }
                    Type resultType1 = Process1.ReturnType;
                    SimpleProcessInfo SimpleProcessInfoP = new SimpleProcessInfo(argList, NameOfSP.ElementAt(0), resultType1);
                    ExecutionSimpleProcess GetValue = new ExecutionSimpleProcess(SimpleProcessInfoP, arg);
                    var Value = GetValue.Execution();
                    Console.WriteLine("\n", Value);
                }
            }
        }

    }
}
