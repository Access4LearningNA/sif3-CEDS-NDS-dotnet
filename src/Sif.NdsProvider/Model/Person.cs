﻿using Sif.Framework.Model.DataModels;
using Sif.Specification.DataModel.Us;

namespace Sif.NdsProvider.Model
{
    public class Person : personType, IDataModel
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