﻿using Sif.Framework.Model.DataModels;
using Sif.Specification.DataModel.Us;

namespace Sif.NdsProvider.Model
{
    public class ContactPersonAssociation: contactPersonAssociationType,IDataModel
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
