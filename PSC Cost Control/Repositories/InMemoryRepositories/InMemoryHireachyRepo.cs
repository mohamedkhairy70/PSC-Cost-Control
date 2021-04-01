

using AutoMapper;
using PSC_Cost_Control.BussinessLogics.HirearchyIdGenerator;
using PSC_Cost_Control.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSC_Cost_Control.Repositories.InMemoryRepositories
{
    public abstract class InMemoryHireachyRepo<T> where T:HasCode
    {
        private Dictionary<string,T> Data;
        private IMapper Map;
        private HireachyIdGenerator<T> CodeGenerator;

        protected InMemoryHireachyRepo(IMapper map)
        {
            Map = map;
            Data = new Dictionary<string, T>();
            CodeGenerator = new HireachyIdGenerator<T>();
        }
        public T Add(T element,T parent,T neighbour)
        {
            var code = CodeGenerator.Generate(parent, neighbour);
            if (Data.ContainsKey(code))
                throw new System.Exception("An elemnt with the same code already exists");
            element.HCode = code;
            Data.Add(code, element);
            return element;
        }

    /**    public T Delete(T element)
        {
            if (element.HCode is null)
                throw new Exception("code is null!");

            if (!Data.ContainsKey(element.HCode))
            {
                throw new Exception("Code not found!");
            }

            Data.Remove(element.HCode);

        }
        private void FixCodes()
        {

        }

        public T Update(string Code,T element,T parent,T neighbour)
        {
        }
    
        **/
    }
}
