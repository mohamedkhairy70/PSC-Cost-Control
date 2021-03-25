using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Helper
{
    public class Static
    {
        public static Int64 _User_Code;
        public static Int64 _Project_Code;

        public void UserName(Int64 User_Code)
        {
            _User_Code = User_Code;


        }
        public Int64 User_Code()
        {
            return _User_Code;


        }





    }
}
