﻿using Sif.Framework.Model.DataModels;
using Sif.Specification.DataModel.Us;

namespace Sif.NdsProvider.Model
{
    public class StudentSectionMarkScores : studentSectionMarkScoresType, IDataModel
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
