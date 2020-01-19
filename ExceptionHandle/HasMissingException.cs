using System;

namespace ToolBox.ExceptionHandle
{
    public class HasMissingException : Exception
    {
        string propList;
        int countID;
        public HasMissingException(string missingProp, int missingID)
        {
            propList = missingProp;
            countID = missingID;
        }

        public string GetMissingProp
        {
            get
            {
                return propList;
            }
        }

        public int MissingIDCount
        {
            get
            {
                return countID;
            }
        }
    }
}