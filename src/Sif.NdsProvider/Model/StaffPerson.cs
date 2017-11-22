using Sif.Framework.Model.DataModels;
using Sif.Specification.DataModel.Us;

namespace Sif.NdsProvider.Model
{
    public class StaffPerson : staffPersonType, IDataModel
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
