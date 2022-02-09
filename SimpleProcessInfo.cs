using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace ProcessInfo
{
    //[DataContract]
    class ArgInfo
    {
        //[DataMember]
        public Type ArgType { get; set; }

        //[DataMember]
        public string Name { get; set; }

        //[DataMember]
        public int Index { get; set; }

        public ArgInfo(Type argType, string name, int index)
        {
            ArgType = argType;
            Name = name;
            Index = index;

        }
    }
    class ProcessInfo
    {
      
        public List<ArgInfo> Args { get; set; }

        
        public string NameOfSimpleProcess { get; set; }

        
        public Type ResultType { get; set; }
        public ProcessInfo(List<ArgInfo> args, string nameOfSimpleProcess, Type resultType)
        {
            Args = args;
            NameOfSimpleProcess = nameOfSimpleProcess;
            ResultType = resultType;
        }
    }


   
    class SimpleProcessInfo : ProcessInfo
    {
        public SimpleProcessInfo(List<ArgInfo> args, string nameOfSimpleProcess, Type resultType)
        : base(args, nameOfSimpleProcess, resultType)
        {
        
        }
    }
}
// Требовалось описать класс дискрепшн, который описывает процесс. Создана класс SimpleProcessInfo 
//который описывает  процесс, состоящееся из одного метода. У процесса есть тип входа, (возможно несколько)
// и тип выхода который представляет результат, а также имеет имя процесса. Тип входа представляет типы параметров метода.
//В классе ComplexProcessInfo описывается сложный процесс, представляестся композициями простых методов.Из характеристики  помимо параметров у
// SimpleProcessInfo входит еще описание композиции т.е алгаритмическая сложность. 
//Экземпляр этого класса строится с помощью рефлекции. Мы передаем в конструктор MethodInfo, который находится в типе System.Reflection.MethodInfo. 
//Этот тип имеет всю информацию для создание экземпляр класса, например как имя параметра и тип
// Цель данной задачи было создать автоматическая композиция вычислительных процессов, это означает что мы вводим имена методов класса через клавуатуру, и параметры первого метода.
//Из этого строится композиция методов. Например, B f1...fn -> fn∘...∘f1(x), х - это параметр первого метода
