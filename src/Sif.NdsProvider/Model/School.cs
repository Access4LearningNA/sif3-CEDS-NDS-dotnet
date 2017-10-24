using Sif.Framework;
using Sif.Framework.Model.DataModels;
using Sif.Specification.DataModel.Us;
using System.Xml.Serialization;

namespace Sif.NdsProvider.Model
{
   
    public class School : SchoolType,IDataModel
    {
        public string RefId
        {

            get
            {
                return refId;
            }
            set
            {
                refId = value;
            }

        }

       
    }
}
