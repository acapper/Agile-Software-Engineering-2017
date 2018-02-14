using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile_2018
{
    public class Project
    {

        int idToView = 0;
        
        public int viewProject(int input)
        {
            ConnectionClass.OpenConnection();

            idToView = input;

            







            return idToView;
            

        }
        




    }
}